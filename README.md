# gShell is out of date - use at your own risk
Unfortunately, gShell is no longer actively maintained. This means there are some dependencies with known vulnerabilities that need to be resolved. This lack of maintenance is a direct result of a career shift away from a windows environment with a strong focus elsewhere. While I would love to continue contributing, my work life balance does not currently allow for this. 

All hope is not yet lost! I was working on a way to auto generate the code for gShell (windows only, not Core - sorry!) and was about 85% of the way to a working version [here](https://github.com/squid808/gShellApiGenerator). The goal was to automate the entire stream from reading the API docs to generating the codebase to committing it to Nuget. Most of the gShell pieces that you may already know and love were working, but it probably needs some polish.

I wish you the best of luck, and maybe someday I can get back in the game.

Regards,

squid808



---


# Welcome to gShell!

## PowerShell Cmdlets for G Suite Administration
gShell is a toolset to help you access and manage information from your G Suite (formerly Google Apps) domain through [Windows PowerShell](http://en.wikipedia.org/wiki/Windows_PowerShell). ([Need some help with the basics](https://github.com/squid808/gShell/wiki/PowerShell-Basics)?)
Simply put, gShell is a native PowerShell wrapper for the APIs that make up the [Google Admin SDK](https://developers.google.com/admin-sdk/).

### What's New?
Version 0.10 beta is now available! With [50 new cmdlets](https://github.com/squid808/gShell/wiki/Cmdlets-Index) added, you can't go wrong! This is the final major update to gShell. [Check out the News page for more,](https://github.com/squid808/gShell/wiki/News) or dive in to the comprehensive [wiki](https://github.com/squid808/gShell/wiki)!

Check out the [Getting Started](https://github.com/squid808/gShell/wiki/Getting-Started) page to get going, or hop over to [Downloads](https://github.com/squid808/gShell/wiki/Downloads) if you want to dive in with the installer.

#### Quick Examples
The idea of gShell is to allow you quick and easy access to your G Suite domain. Check out some of the following examples to see how this can be helpful to you, once you get past the [quick setup](https://github.com/squid808/gShell/wiki/Getting-Started).

- Easily [retrieve a user](https://github.com/squid808/gShell/wiki/Get-GAUser) from your domain:

```PowerShell
PS C:\> Get-GAUser BMcGee

GivenName     : Bobby
FamilyName    : McGee
PrimaryEmail  : bmcgee@mydomain.com
Aliases       : {bobbymcgee@mydomain.com, bobmcgee@mydomain.com}
Suspended     : False
OrgUnitPath   : /
LastLoginTime : 2013-10-25T05:10:40.000Z
```
- Get all users in the domain as a variable:

```PowerShell
PS C:\> $AllUsers = Get-GAUser -all

----
PS C:\> $AllUsers.Count

9001
```

- Get a list of all members in a [Google group](https://github.com/squid808/gShell/wiki/Get-GAGroupMember):

```PowerShell
PS C:\> $Members = Get-GAGroupMember SomeGroupName

----
PS C:\> $Members.Count

42
```
- Export members of all groups in to a CSV:

```PowerShell
PS C:\> $AllMembers = New-Object System.Collections.ArrayList

foreach ($Group in (Get-GAGroup -All)) {
    if ($Group.DirectMembersCount -gt 0) {
        $Members = Get-GAGroupMember $Group.Email

        foreach ($Member in $Members) {
            $Member | Add-Member -NotePropertyName "Group" -NotePropertyValue $Group.Email
            $AllMembers.Add($Member) | Out-Null
        }
    }
}

----
PS C:\> $AllMembers[0]

Group : songcharacters@mydomain.com
Email : bobbymcgee@mydomain.com
ETag  : "01...rs/44...HQ"
Id    : 123456789123456789123
Kind  : admin#directory#member
Role  : MEMBER
Type  : USER

----
PS C:\> $AllMembers | Export-Csv -Path "C:\AllGroupMemberships.csv" -NoTypeInformation

----
PS C:\> (Get-Content "C:\AllGroupMemberships.csv")[0..1]
#Let's look directly at the CSV file...

"Group","Email","ETag","Id","Kind","Role","Status","Type"
"songcharacters@mydomain.com","bobbymcgee@mydomain.com",
"""01...rs/44...HQ""","12...23","admin#directory#member","MEMBER","USER"

```

This is the tip of the iceberg of what's possible and what's available. If you need help or have questions, drop a line in the [discussion group](https://github.com/squid808/gShell/wiki/Discussion-Groups).

Alternately, please file bugs and issues in the [issue tracker](https://github.com/squid808/gShell/issues).
