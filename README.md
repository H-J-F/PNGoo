PNGoo
=====

The modifications of this forked version of PNGoo:
- Update to .NET Framework 4.7.2.
- Multi -folder selection (multiple selection, recursive selection, including all the .png format files in all sub -directory).
- The original file will not be covered if the compressed file size is larger and the original file is not encoded in PNG format, unless the check box of Force PNG is checked.
- Added support for arguments during command-line execution:
    - "-p" / "-Path": The target file path or directory to be compressed. Both specific file path and directory path are supported.
    - "-OutputPath": The output path for compressed PNG files.
    - "-ForcePng": This option forces files to be compressed into PNG format, even if the original file is not PNG encoded. This will result in non-PNG encoded images (those with a .png extension but not PNG encoded) being overwritten, even if the compressed image takes up more space.
    - "-OverwriteIfLarger": Overwrite the origin file even if the compressed image takes up more space.

    Example: PNGoo.exe -Path="C:/YourPngFilesPath/" -OutputPath="C:/YourPngOutputPath/" -ForcePng="false" -OverwriteIfLarger="false"

The following is the content of the README.md file for the original project
=====

My modifications of the PNGoo batch PNG processor: http://code.google.com/p/pngoo/

Still playing with the project - so far my changes are:
- Multithreading: the GUI no longer is unresponsive while processing, and four files may be processed simultaneously
- Improved GUI: Status text accompanied by a shiny progress bar, and a cancel button


Things I would like to add:
- Entire directory selection (not just this laggy "add files" Windows dialogue) with a recursive option
- Probably more.
