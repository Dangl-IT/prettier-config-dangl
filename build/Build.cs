using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static Nuke.Common.Tools.Npm.NpmTasks;
using System.IO;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Restore);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [GitVersion(Framework = "net6.0", NoFetch = true)] GitVersion GitVersion;

    Target Restore => _ => _
        .Executes(() =>
        {
            Npm("ci", RootDirectory);
        });

    Target BuildLibrary => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            Npm($"version {GitVersion.NuGetVersion}  --no-git-tag-version", RootDirectory);
        });

    Target TestLibrary => _ => _
    .DependsOn(BuildLibrary)
    .Executes(() =>
    {
        Npm("test", RootDirectory);
    });

    Target Publish => _ => _
    .DependsOn(BuildLibrary)
    .OnlyWhenDynamic(() => IsOnBranch("main") || IsOnBranch("develop"))
    .Executes(() =>
    {
        var npmTag = IsOnBranch("master")
            ? "latest"
            : "next";
        Npm($"publish --access public --tag={npmTag}", RootDirectory);
    });

    private bool IsOnBranch(string branchName)
    {
        return GitVersion.BranchName.Equals(branchName) || GitVersion.BranchName.Equals($"origin/{branchName}");
    }
}
