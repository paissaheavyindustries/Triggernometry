## What are repositories?

Repositories are remote collections of triggers that can be added to Triggernometry. Triggernometry will then automatically update these repositories, giving you the latest updates and triggers for the latest content automatically, without having to do anything yourself.

A repository generally has a theme, for example a raid trigger repository would give you triggers related to raids, but not triggers related to dungeons.

## How to use repositories?

It's quite easy - right click on "Remote triggers", and select "Add repository from list". Triggernometry will download the manifest.xml from Github, and present all available and known repositories for you to choose from.

Alternatively, you can add a repository manually in Triggernometry by selection "Add repository", and specify an address to the repository file (generally a XML file).

## How to create my own repository?

It's as easy as taking an export in Triggernometry and making that available on the Internet. When you want to update the repository, simply update the contents of the file.

## Other tech stuff

Triggernometry detects changed repositories by doing a HTTP HEAD request. If the last modified date is set and it has changed, or content length has been set and it has changed, Triggernometry will redownload the source file. If neither of those have changed, then Triggernometry will use local cache instead.
