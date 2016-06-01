# Pasta [![Build status](https://ci.appveyor.com/api/projects/status/tr31lvssfbfomase?svg=true)](https://ci.appveyor.com/project/TomasBouda/pasta)

<img src="https://raw.githubusercontent.com/TomasBouda/Pasta/master/pasta.PNG" align="right">
**Pastebin.com helper utility**

Transforms your code into pastebin link.


<br/>
## How to use it
<img align="right" src="https://raw.githubusercontent.com/TomasBouda/Pasta/master/pasta_config.PNG" alt="options">
On first start, you will need to set your API key.

Go to [pastebin.com/api](http://pastebin.com/api) (you will need to log in). You will see your API key in box down below (see the picture). Copy the key and paste it into Api key field. Right now you are ready to make pastas as guest.

<img src="http://s33.postimg.org/6k6bvsdbj/pastebin_apikey_c.png">

Just copy some code <kbd>CTRL</kbd>+<kbd>C</kbd> and hit <kbd>CTRL</kbd>+<kbd>ALT</kbd>+<kbd>C</kbd>, Pasta will swap your code in clipboard with pastebin link. All you need to do now, is just send it to someone :wink:

### Paste as user
Open Pasta options and go to "Get user key" section. Fill in you credentials and hit Authenticate. If authentication was successfull, you will see User key in a filed. Now as user, you are not limited to amount of pastas per day.

### More options
Pasta allows you to set more options, like 
* Format - syntax highlithing, eg. csharp
* Expiration -  eg. 1D
* Paste mode - Public, Unlisted, Private

*For more info see [pastebin.com/api](http://pastebin.com/api)* :octocat:

Pasta also log your pastes into text file. Open Pasta folder and see ``` /pasta_history.txt ```
