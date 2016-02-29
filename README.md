# EloHeaven

Elo Heaven is a League of Legends community focused on helping players improve their game. Check out our website: http://eloheaven.gg

Elo Heaven is currently in extremely early stages of development and will initially be focused on providing support for our "Mentored Inhouses".

Elo Heaven currently targets .NET4.6.1 and is built using MVC5, WebAPI2, AngularJS and Bootstrap, with a view to keep up to date with the latest versions when applicable.

## Getting Started with helping out

To help out in the development of the Elo Heaven application, you'll need a copy of Visual Studio ([Visual Studio 2015 Community](https://www.visualstudio.com/downloads/download-visual-studio-vs) is great and free).

Once you've done this, you need to do the following:

* Fork and clone the repository.
* Open up the solution in Visual Studio.
* In the EloHeaven project create a new file named `settings.config`
* Copy and paste the following into your new file:

``` xml
<?xml version="1.0"?>
<appSettings>
  <add key="RiotApiKey" value="Your Developer API Key Here"/>
</appSettings>
```
* Log into the [Riot Developer Portal](https://developer.riotgames.com/) and replace the `RiotApiKey` value with your Development API Key.
* Start the application and make sure everything works.

If you have any problems with getting set up, don't hesistate to make an issue and we'll sort it out.
