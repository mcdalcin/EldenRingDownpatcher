

# ELDEN RING Downpatcher (steam only)
Fork of the Doom Eternal Downpatcher for Elden Ring because better game :).

![Preview](https://github.com/mcdalcin/EldenRingDownpatcher/blob/master/Images/preview10.PNG?raw=true)


Made with love from Xiae.

  ![XiaeKawaii](https://github.com/mcdalcin/EldenRingDownpatcher/blob/master/Images/kawaii.jpg?raw=true)

## INSTRUCTIONS

Instructions included in the application under the Help link in the top right.

## BELOW IS FOR DEVELOPERS ONLY

## ADDING SUPPORT FOR NEW VERSION

When adding in a new version, two things should be done. Note that the downpatcher will always work if the Download All Files option is selected; however, also note that downloading from steam depots is extremely slow and less files needed is usually better.

 - Adding in the filelist.
 - Modifying data/versions.json with the manifest and size information.

### ADDING IN THE FILELIST

The FileListGenerator makes this part very easy. Simply get the patch notes page from [SteamDB](https://steamdb.info/app/782330/patchnotes/) and enter it into the FileListGenerator. Follow the directions carefully. An example usage with the March 17 2022 patch is below.

![FileListGenerator](https://github.com/mcdalcin/DoomEternalDownpatcher/blob/master/Images/fileListGenerator.PNG?raw=true)

Rename the filelist.txt created to new_version_name.txt and add it to the data folder in this repository.

### MODIFY VERSIONS.JSON

**Eventually, this part can be automated, but for now we must do it manually.**

Each version will contain a new manifest id for each depot that has changed.

##### CREATE AN ENTRY FOR THE NEW VERSION

To begin, edit data/versions.json and add in a new entry based on the previous version.  For example, if we are adding in version 1.03, begin by creating a copy of the previous patch (1.02.3).

```json
      {
          "name": "1.02.3",
          "size": "82691400",
          "manifestIds": [
              "8390693081119963338",
              "2484355486124511110"
          ]
      },
```

##### ADJUST MANIFESTIDS FOR THE NEW VERSION

The manifestIds correspond to the 2 steam depots 1245621 and 1245624. Note that a manifest id will only change for the depot if it contained changes from the previous patch.

To get the new manifestIds, go to https://steamdb.info/app/1245620/patchnotes/. Click on the current patch (in this example, the March 17th 2022 patch corresponds to version 1.03). Once there, get the new manifest ids for depot 1245621 and 1245624. Note that a depot may not contain any changes for a new patch. If this is the case, the manifest id may or may not change.

If done correctly, the versions.json should not contain a new entry for 1.03 as follows:

```json
      {
          "name": "1.02.3",
          "size": "82691400",
          "manifestIds": [
              "8390693081119963338",
              "2484355486124511110"
          ]
      },
      {
          "name": "1.03",
          "size": "82774344",
          "manifestIds": [
              "4121984677645683704",
              "1984118169889838981"
          ]
      }
```
##### UPDATING THE SIZE FOR THE NEW VERSION
The final thing that will need updating is the size. This is the size of the eldenring.exe executable located in your Steam folder. Right click it, go to properties, and copy and paste the size in bytes (NOT the size on disk).

#### FINALLY, COMMIT THE NEW VERSIONS.JSON AND TEST THE DOWNPATCHER!
