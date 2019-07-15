## What are repositories?

Repositories are remote collections of triggers that can be added to Triggernometry. Triggernometry will then automatically update these repositories, giving you the latest updates and triggers for the latest content automatically, without having to do anything yourself.

## How to use repositories?

It's quite easy - just add a repository in Triggernometry under "Remote triggers", and specify an address to a repository file (generally a XML file).

## How to create my own repository?

It's as easy as taking an export in Triggernometry and making that available on the Internet. When you want to update the repository, simply update the contents of the file.

## Known repositories

Triggernometry's own default repository is right here on Github:
* https://raw.githubusercontent.com/paissaheavyindustries/Triggernometry/master/Repositories/default.xml

## Other tech stuff

Triggernometry detects changed repositories by doing a HTTP HEAD request. If the last modified date is set and it has changed, or content length has been set and it has changed, Triggernometry will redownload the source file. If neither of those have changed, then Triggernometry will use local cache instead.
