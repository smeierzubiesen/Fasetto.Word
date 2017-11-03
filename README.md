# Fasseto-Word
This is my take on Fasetto Word from Angel six

Current branch build status:
[![Build status](https://ci.appveyor.com/api/projects/status/m3yhr8wmqq42gylh?svg=true)](https://ci.appveyor.com/project/smeierzubiesen/fasseto-word)

Master branch build status:
[![Build status](https://ci.appveyor.com/api/projects/status/m3yhr8wmqq42gylh/branch/master?svg=true)](https://ci.appveyor.com/project/smeierzubiesen/fasseto-word/branch/master)

Coverity Scan Build Status (WIP):
[![Coverity Scan Build Status](https://img.shields.io/coverity/scan/13957.svg)](https://scan.coverity.com/projects/smeierzubiesen-fasetto-word)

Codacy Code Quality
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/34380d9b86a94d6182046b27113cdc98)](https://www.codacy.com/app/JokerSolutions/Fasetto.Word?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=smeierzubiesen/Fasetto.Word&amp;utm_campaign=Badge_Grade)

Core Infrastructure Initiative
[![BlackDuck Badge](https://bestpractices.coreinfrastructure.org/projects/1/badge)](https://www.openhub.net/p/Fasetto_Word)

Documentation Build Status for master branch
[![ReadTheDocs Badge](https://readthedocs.org/projects/fasettoword/badge/?version=latest)](http://fasettoword.readthedocs.io/en/latest/)

Documentation Build Status for dev branch
[![ReadTheDocs Badge](https://readthedocs.org/projects/fasettoword/badge/?version=dev)](http://fasettoword.readthedocs.io/en/dev/)

## Progress
I have so far managed to follow up to lesson 15 and also managed to include some few changes of my own.

### Documentation
After much deliberation and trial-and-error (more error than anything lol) I have managed to make ReadTheDocs.io the main source for the docs.
After my initial attempt at generating the docs from source, via doxygen on Appveyor, I have finally realized that none of that was necessary.
Appveyor only needs to build the app itself. ReadTheDocs is perfectly capable of generating the documentation by first calling doxygen and the generating reStructured text from those sources.

_I'm seriously considering to put doxygen back though, so it can at least generate HTML files from my documentation, while appveyor does its thing, although the build time on appveyor has *dramatically* decreased, so yeah_