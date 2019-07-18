## What are repositories?

Repositories are remote collections of triggers that can be added to Triggernometry. Triggernometry will then automatically update these repositories, giving you the latest updates and triggers for the latest content automatically, without having to do anything yourself.

A repository generally has a theme, for example a raid trigger repository would give you triggers related to raids, but not triggers related to dungeons.

## How to use repositories?

It's quite easy - right click on "Remote triggers", and select "Add repository from list". Triggernometry will download the manifest.xml from Github, and present all available and known repositories for you to choose from.

Alternatively, you can add a repository manually in Triggernometry by selection "Add repository", and specify an address to the repository file (generally a XML file).

## How to create my own repository?

It's as easy as taking an export in Triggernometry and making that available on the Internet. When you want to update the repository, simply update the contents of the file.

If you have created a repository or are maintaining one, throw me a DM on Discord (Locrian Mode#2318) and you'll get permission to send messages to the update channel on Triggernometry's Discord. I can also add your repository to the master list, so that it will appear on Triggernometry's repository selection!

## Other tech stuff for nerds (cool people don't look)

Triggernometry detects changed repositories by doing a HTTP HEAD request. If the last modified date is set and it has changed, or content length has been set and it has changed, Triggernometry will redownload the source file. If neither of those have changed, then Triggernometry will use local cache instead.

Folder and trigger IDs may be duplicated between local triggers and repository triggers, or even between repositories, but that's not a problem. Each repository lives in its own address space/sandbox when it comes to folder and trigger IDs. Triggers in a repository can't fire or manipulate triggers/folders outside of their own repository, whether it's local triggers or other repositories. Likewise, local triggers can't refer to triggers in repositories. 
