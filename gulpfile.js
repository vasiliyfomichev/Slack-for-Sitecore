var gulp = require("gulp");
var runSequence = require("run-sequence");
var path = require("path");
var msbuild = require("gulp-msbuild");
var debug = require("gulp-debug");
var gulpPrint = require("gulp-print");
var clean = require("gulp-clean");
var merge = require("gulp-ilmerge");
var mkdirp = require('mkdirp');

var config = {
  websiteRoot: "C:\\websites\\Habitat.local\\Website",
  buildConfiguration: "Debug"
}

var buildProject = function (location) {
  return gulp.src(location)
      .pipe(gulpPrint())
      .pipe(debug({ title: "Building project:" }))
      .pipe(msbuild({
        targets: ["Build"],
        configuration: config.buildConfiguration,
        logCommand: false,
        verbosity: "minimal",
        maxcpucount: 0,
        toolsVersion: 14.0
      }))
};

gulp.task("Build-Slack", ["Clean-Slack"], function () {
  return buildProject("Slack/Slack.csproj");
});

gulp.task("Publish-Slack.Core", function () {
  return buildProject("Slack.TDS.Core/Slack.TDS.Core.scproj");
});

gulp.task("Publish-Slack.Master", function () {
  return buildProject("Slack.TDS.Master/Slack.TDS.Master.scproj");
});

gulp.task('Clean-Slack', function () {
  return gulp.src('Slack/bin/*.*', { read: false })
    .pipe(clean());
});

gulp.task("Publish-Configs", function () {
  var files = "Slack/App_Config/**/*.config";
  var destination = config.websiteRoot + "\\App_Config";
  return gulp.src(files)
    .pipe(debug({ title: "Copying " }))
    .pipe(gulp.dest(destination));
});

gulp.task("Merge-Assemblies", ["Build-Slack", "Create-OutputFolder"], function () {
  return gulp.src(["Slack\\bin\\Slack.dll",
                  "Slack\\bin\\SlackConnector.dll",
                  "Slack\\bin\\RestSharp.dll",
                  "Slack\\bin\\websocket-sharp-with-proxy-support.dll",
                  "Slack\\bin\\Newtonsoft.Json.dll"])
    .pipe(merge({
          libPath: "lib/",
          outputFile: "output/Slack.dll",
          ilmergePath: "packages\\ILMerge.2.14.1208\\tools\\ilmerge.exe"
        }))
});

gulp.task('Create-OutputFolder', function (cb) {
  mkdirp('output', cb);
});

gulp.task("Publish-Assemblies", ["Merge-Assemblies"], function () {
  var binFiles = "output/**/*.{dll,pdb}";
  var destination = config.websiteRoot + "/bin/";
  return gulp.src(binFiles)
    .pipe(debug({ title: "Copying " }))
    .pipe(gulp.dest(destination));
});

gulp.task("Publish-All", function (callback) {
  runSequence(
    "Publish-Slack.Core",
    "Publish-Slack.Master",
    "Publish-Configs",
    "Publish-Assemblies", callback);
});