<h2 align="center">VersionUpdater.Net  <img src="https://github.com/EmreSeverr/VersionUpdater.Net/blob/master/VersionUpdater.Net/Resources/VersionUpdaterLogo.png" height="25"> </h2>

<div align="center"> 

[![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/EmreSeverr/VersionUpdater.Net/blob/master/LICENSE) 
[![NuGet](https://img.shields.io/nuget/v/VersionUpdater.Net)](https://www.nuget.org/packages/VersionUpdater.Net/) 
[![NuGet](https://img.shields.io/nuget/dt/VersionUpdater.Net)](https://www.nuget.org/packages/VersionUpdater.Net/) 
[![Nuget Package](https://github.com/EmreSeverr/VersionUpdater.Net/actions/workflows/ciNuget.yml/badge.svg?branch=master)](https://github.com/EmreSeverr/VersionUpdater.Net/actions/workflows/ciNuget.yml)

</div>

Performs automatic updating for .NET forms projects using github actions.

Supported versions :
- .Net 5.0.0

Dependencies :
- Cronos (>= 0.7.1)
- MetroFramework (>= 1.2.0.3)
- Microsoft.Extensions.Hosting.Abstractions (>= 5.0.0)
- Octokit (>= 0.50.0)

### Features
- Checks for updates at each startup.
- Checks for updates at runtime. (Optional.)
- Update notes page for user. (Version 2.0.0 and later.)
- Publish an update as mandatory or non-mandatory.
- Turkish and English language supported. (For the update page.)


## Configurations For Updates

> Download VersionUpdater.Net from [Nuget](https://www.nuget.org/packages/VersionUpdater.Net/) to your project.

Github actions are used for updates. Firstly, you must put the [dotnet.yml](https://github.com/EmreSeverr/VersionUpdater.Net.Sample/blob/master/.github/workflows/updater.yml)
file in the "/.github/workflows/" folder for the project that you want to apply the update feature to. And you have to adjust the [dotnet.yml](https://github.com/EmreSeverr/VersionUpdater.Net.Sample/blob/master/.github/workflows/updater.yml) file configuring to your own project.
Just change the variable named "PROJECT_PATH" in the environment.

Example:
> PROJECT_PATH: VersionUpdater.Net.Sample/VersionUpdater.Net.Sample.csproj
> 
> REPOSITORY: "EmreSeverr/VersionUpdater.Net.Sample"

Then your project *.csproj file, you must enter "Version" information and "UpdateRequired" information.

Example:
```
<PropertyGroup>
...
    <Version>1.0.0</Version>
    <UpdateRequired>false</UpdateRequired>
...
</PropertyGroup>
```

After these operations, after each Github push operation, your project is taken to build and added as an executable file in release.
> If you do not increase the version number, release will not occur and you will not have published an update.

Then, add the following code to the "Program.cs" file. And adjust it according to your own project.

```
static async Task Main()
{
...
  await Updater.ApplyVersionUpdaterAsync(p =>
  {
      p.Owner = {Owner Name};
      p.RepositoryName = {Your Repository Name};
      p.GithubAuthenticationType = GithubAuthenticationType.Bearer;
      p.GithubToken = {Your Github Token};
      p.ScheduleConfig = new ScheduleConfig()
      {
        CronExpression = @"* * * * *",
        TimeZoneInfo = TimeZoneInfo.Local
      };
  }).ConfigureAwait(false);
            
  Application.Run(new Form1());
...
}
```
#### Parameters:
| Parameter Name | Is Required | Description |
| -------------- | ----------- | ----------- |
| Owner | :heavy_check_mark: | Owner name of your repository. |
| RepositoryName | :heavy_check_mark: | Name of your repository. |
| GithubAuthenticationType | :heavy_check_mark: | Github authentication type. |
| GithubToken | :x: | Your Github personnel access token. If your Github repository is private, you must enter the personnel access token. |
| ScheduleConfig | :x: | Will there be runtime Update Check? CronExpression and TimeZoneInfo must be entered if it will be. Otherwise it should be null. ([Generate CronExpression](http://www.cronmaker.com/))

If you have published a new update and you force the update to the user, the page on the right is displayed, if you do not, the page on the left is displayed.

Mandatory Update             |  Non-Mandatory Update
:-------------------------:|:-------------------------:
<img src="https://github.com/EmreSeverr/VersionUpdater.Net/blob/master/VersionUpdater.Net/Resources/UpdateReqired.png" height="450" style="float:left;"> | <img src="https://github.com/EmreSeverr/VersionUpdater.Net/blob/master/VersionUpdater.Net/Resources/UpdateNotReqired.png" height="450" style="float:left;">

##### So to publish the update, all you have to do is increase the version and push github. :blush:

However, you can look at my sample [project](https://github.com/EmreSeverr/VersionUpdater.Net.Sample) and download and try the [releases](https://github.com/EmreSeverr/VersionUpdater.Net.Sample/releases) I have published.

#### For Version 2.0.0 And Later:
- Added the update notes page.

To add an update note, you must enter "UpdateDescription" information in "PropertyGroup". If you want to enter more than one update note, you can divide them with the '#' character.

Example:
```
<PropertyGroup>
...
    <UpdateDescription>New Update.#New Release.#New Version.</UpdateDescription>
...
</PropertyGroup>
```

> If you do not enter an update note, "UpdateNotes" will not visible on the update page.

And update note page looks like this :

<img src="https://github.com/EmreSeverr/VersionUpdater.Net/blob/master/VersionUpdater.Net/Resources/UpdateNotes.png" height="450" style="float:left;">
