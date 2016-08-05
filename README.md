# Welcome to gShell!

## What is gShell?
gShell is a project that primarily aims to make any Apps Admin-related Google APIs available through Microsoft PowerShell, starting with the Administrative APIs. As a result, gShell also provides dotNet developers with a [framework to ease the burden of authenticating and calling on the APIs in dotNet](https://github.com/squid808/gShell/wiki/DotNet-Guide).

### What's New?
Version 0.9 beta is now available! Over [250 new cmdlets](https://github.com/squid808/gShell/wiki/Cmdlets-Index) added, covering a whopping 15 APIs and more. This is the final major update to gShell. [Check out the News page for more!](https://github.com/squid808/gShell/wiki/News)

Note: A handful of breaking changes have been made, so please be sure to test.
Note: I'm calling this a beta release because it's so big I couldn't test it all. Please try it out and [let me know how it works](https://github.com/squid808/gShell/wiki/Discussion-Groups) or [file an issue if you find one!](https://github.com/squid808/gShell/issues).

### PowerShell Cmdlets for Google APIs

gShell is a toolset to help you access and manage information from your Google Apps domain through [Windows PowerShell](http://en.wikipedia.org/wiki/Windows_PowerShell).

Check out the [Getting Started](https://github.com/squid808/gShell/wiki/Getting-Started) page to get going, or hop over to [Downloads](https://github.com/squid808/gShell/wiki/Downloads) if you want to dive in with the installer.

Please keep an eye on the documentation here in the [Wiki](https://github.com/squid808/gShell/wiki) for what is available; this is a work in progress done in my spare time so things are added irregularly but as frequently as possible.

Finally, I'm always open to adding something new, so if you have an idea [let me know](https://github.com/squid808/gShell/wiki/Discussion-Groups)! Alternately, please file bugs and issues in the [issue tracker](https://github.com/squid808/gShell/issues).

#### Quick Examples
The idea of gShell is to allow you quick and easy access to your Google Apps domain. Check out some of the following examples to see how this can be helpful to you, once you get past the [quick setup](https://github.com/squid808/gShell/wiki/Getting-Started).

First, you can grab a user from your domain and get it back as a [GAUser](https://github.com/squid808/gShell/wiki/GAUser) object:
```PowerShell
PS C:\> Get-GAUser BMcGee mydomain.com

GivenName     : Bobby
FamilyName    : McGee
PrimaryEmail  : bmcgee@mydomain.com
Aliases       : {bobbymcgee@mydomain.com, bobmcgee@mydomain.com}
Suspended     : False
OrgUnitPath   : /
LastLoginTime : 2013-10-25T05:10:40.000Z
```
Or, you can elect to get all users in the domain and throw them in a variable, perhaps to compare against your AD Environment:

```PowerShell
PS C:\> $AllUsers = Get-GAUser -all

----
PS C:\> $AllUsers.Count

9001
```

Better yet, perhaps you need to get a list of all users in all [groups](https://github.com/squid808/gShell/wiki/Get-GAGroup) in the domain...
```PowerShell
PS C:\> $AllGroups = Get-GAGroup mydomain.com -All -Members -Owners
#A progress bar will show up for this, since it's potentially a long wait

----
PS C:\> $AllGroups.Count

42
```
...or you want to find all members of all groups, and throw that in a list for easy export to CSV Got that covered:

```PowerShell
PS C:\> $AllMembers = (Get-GAGroupMember -All).ToSingleList()

----
PS C:\> $AllMembers[0]

Email : bobbymcgee@mydomain.com
ETag  : "01...rs/44...HQ"
Id    : 123456789123456789123
Kind  : admin#directory#member
Role  : MEMBER
Type  : USER
Group : songcharacters@mydomain.com

----
PS C:\> $AllMembers | Export-Csv -Path "C:\AllGroupMemberships.csv" -NoTypeInformation

----
PS C:\> (Get-Content "C:\AllDomainGroupMemberships.csv")[0..1]
#Let's look directly at the CSV file...

"Email","ETag","Id","Kind","Role","Type","Group"
,"""01...rs/44...HQ""","12...23","admin#directory#member","MEMBER","USER"
,"songcharacters@mydomain.com"
```

This is the tip of the iceberg of what's possible and what's available. If you need help or have questions, requests or you found a bug, drop a line in the [discussion group](https://github.com/squid808/gShell/wiki/Discussion-Groups).

Please reach out if you have any questions, concerns or requests.
