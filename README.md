gShell
======

Note: during the transition between Google Code and Github, some links and information will need to be recreated from scratch. Please bear with me while I recreate it, or let me know if you'd like to contribute to the wiki OR to the code!

####Welcome to gShell!####

gShell is here to help you access information from your Google Apps domain through the PowerShell scripting language. Please keep an eye on the documentation here in the Wiki for what is available; this is a work in progress done in my spare time, so things are added irregularly but as frequently as possible.

Please check the _Getting Started_ page to get going, or hop over to _Downloads_ if you want to dive in.

####What's New?####
Unfortunately the previous versions and their information (up until version 0.0.4.0) have been lost in the transition from Google Code to Github. So we'll have to start here unless someone can find a cached version I couldn't! Right now I'm waiting on an issue to be resolved in the code that this project is based on, and once that is done I'll have a new release ready that will resolve an annoying bug and add a ton of new cmdlet features! 0.0.5.0, here we come!

####Quick Examples####
The goal of gShell is to allow you quick and easy access to your Google Apps domain. Down the road, I hope to expand it to include additional google APIs that can be used with _ANY_ Google-based account. Check out some of the following examples to see how this can be helpful to you, once you get past the _quick setup_.

First, you can grab a user from your domain and get it back as a _GAUser_ object:
```
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

```
PS C:\> $AllUsers = Get-GAUser -all

----
PS C:\> $AllUsers.Count

9001
```

Better yet, perhaps you need to get a list of all users in all groups? in the domain...
```
PS C:\> $AllGroups = Get-GAGroup mydomain.com -All -Members -Owners
#A progress bar will show up for this, since it's potentially a long wait

----
PS C:\> $AllGroups.Count

42
```
...or you want to find all members of all groups, and throw that in a list for easy export to CSV? Got that covered:

```
PS C:\> $AllMembers = (Get-GAGroupMember -All).ToSingleList()

----
PS C:\> $AllMembers[0]

Email : bobbymcgee@mydomain.com
ETag  : "0123456789abcdefghijklmoprs/444R0-jMGNMOs3vjjmXpfjzQHHQ"
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
,"""0123456789abcdefghijklmoprs/444R0-jMGNMOs3vjjmXpfjzQHHQ""","123456789123456789123","admin#directory#member","MEMBER","USER"
,"songcharacters@mydomain.com"
```

This is the tip of the iceberg of what's possible and what's available. If you need help or have questions, requests or you found a bug, drop a line in the _discussion group_.

Stay tuned, and please reach out if you have any questions, concerns or requests.
