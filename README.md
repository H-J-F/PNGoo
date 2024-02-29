PNGoo
=====

The modifications of this forked version of PNGoo:
- Update to .net 4.7.2.
- Multi -folder selection (multiple selection, recursive selection, including all the .png format files in all sub -directory).
- The original file will not be covered if the compressed file size is larger and the original file is not encoded in PNG format, unless the check box of Force PNG is checked.

The following is the content of the README.md file for the original project
=====

My modifications of the PNGoo batch PNG processor: http://code.google.com/p/pngoo/

Still playing with the project - so far my changes are:
- Multithreading: the GUI no longer is unresponsive while processing, and four files may be processed simultaneously
- Improved GUI: Status text accompanied by a shiny progress bar, and a cancel button


Things I would like to add:
- Entire directory selection (not just this laggy "add files" Windows dialogue) with a recursive option
- Probably more.
