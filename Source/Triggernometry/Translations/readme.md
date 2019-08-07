## How to create or use translations

It's quite easy - just create an XML file with your preferred name and the extension "`.triglations.xml`". Triggernometry will look into both ACT's configuration directory, and Triggernometry plugin file's current directory for any translation files, and loads them on startup. If you are using a premade translation, just drop it in either of those directories, and it will be loaded the next time Triggernometry starts.

While `default.triglations.xml` is a dump of the default language used in the user interface, changing this file and having it found does not change the default language - you will simply get another entry in the language menu. The default language is built-in and cannot be changed.

## Translation XML structure

Root element is always `Language`, with the following attributes:

* `LanguageName`: the name that will be presented on the user interface.
* `MissingKeyHandling`: what Triggernometry does in case a translation is needed but there is no entry with the corresponding key. Possible values are:
    * `DefaultLanguage` = Display a string from the default language
    * `DefaultString` = Display a default string defined in the translation file (this has the key "`internal/default`")
    * `OutputKey` = Display the key

Under `Language` you will have a container `Translations`, which contains a number of `TranslationEntry` elements. They have the following attributes:

* `Key` = Key used by Triggernometry to look for a translation, generally tries to be descriptive of what it's supposed to be for
    * Some keys may have brackets such as `ActionForm/cbxActionType[Discord webhook]` - this refers to options situated inside a combobox or similar components
* `Translation` = Translation entry 

## Contributions

Please feel free to contribute translations to your preferred languages! I have created a Finnish translation myself as a proof-of-concept translation and for testing.
