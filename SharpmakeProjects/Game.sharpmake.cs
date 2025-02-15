﻿using System.IO;

using Sharpmake;

[module: Sharpmake.Include("BaseProject.sharpmake.cs")]
[module: Sharpmake.Include("Engine.sharpmake.cs")]

[Generate]
public class Game : BaseProject
{
    public Game() : base()
    {
        //The directory that contains the source code that we want include to the project
        SourceRootPath = Path.Combine(MyOptions.RootPath, "Game");

        AddTargets(MyOptions.GetCommonTarget());
    }

    public override void ConfigureAll(Configuration conf, Target target)
    {
        base.ConfigureAll(conf, target);

        conf.Output = Configuration.OutputType.Exe;

        conf.VcxprojUserFile = new Configuration.VcxprojUserFileSettings();
        conf.VcxprojUserFile.LocalDebuggerWorkingDirectory = MyOptions.RootPath;

        // For inherited properties such as include paths and library paths,
        // Sharpmake provides the option to choose between public and private dependencies.
        // Private dependencies are not propagated to dependent projects
        conf.AddPublicDependency<Engine>(target);

        conf.PrecompHeader = "Game/pch.h";
        conf.PrecompSource = "Game/pch.cpp";
    }
}
