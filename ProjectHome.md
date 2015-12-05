## What is it? ##

RealTemp4RTSS is a small utility designed to allow your CPU temperature, frequency and current load to be shown whilst gaming.  Instead of yet another application which monitors and displays this information, RealTemp4RTSS simply passes information from [RealTemp](RealTemp.md) through to the On Screen Display which comes as part of MSI [Afterburner](Afterburner.md) and EVGA [Precision](Precision.md), which means you can keep the utilities you already have, know and trust.

## Why bother? ##

There are a number of programs which can be used to get CPU and GPU information in game but I personally like RealTemp and [Afterburner](Afterburner.md) as they both work well and having an Intel processor and an MSI graphics card were the obvious choice for me.

Sadly, whilst RealTemp can integrate with RivaTuner (on which [Afterburner](Afterburner.md) is based) it can't integrate with [Afterburner](Afterburner.md) itself due to the removal of the plugin functionality RivaTuner once possessed.

Finally, I like little projects such as this and maybe making it available to the world will help someone else... who knows?


## How does it work? ##

Whilst RealTemp doesn't have an API which can be used to retrieve information from it, it does have a plugin intended to integrate with RivaTuner and a user interface which makes it easy to "screen-scrape" the information required.

For the moment RealTemp4RTSS uses the latter method of 'integrating' with RealTemp, which whilst not as clean as the former, is a lot quicker to implement and since releases of RealTemp are few and far between these days, is also less likely to be broken by an update, which is normally a concern when using "screen-scraping".

In the future this method of integration may change, or if the developers of RealTemp decide its worth their time they may integrate with RTSS directly and thereby render this utility useless... only time will tell!

## What can it show? ##

Because it is effectively just a conduit to the information in RealTemp it is somewhat limited in its capabilities; currently only the following can be displayed:

  * The individual temperatures of cores 0, 1, 2 and 3 from your CPU
  * The highest temperature out of cores 0, 1, 2 and 3 from your CPU
  * Total processor load, i.e. the amount that ALL cores of your CPU are being used
  * Processor frequency in either MHz or GHz

In addition to the above, version 1.1 also introduced the ability to display the current time.


## What does it look like? ##

Here's a screenshot of the application running alongside RealTemp:

![![](http://s14.postimage.org/jmdnd5t25/Real_Temp4_RTSS.png)](http://s14.postimage.org/5fxwhxi75/Real_Temp4_RTSS.png)

And here's a screenshot showing Highest Core Temperature, Total Load and Processor Frequency whilst in game:

![![](http://s14.postimage.org/wf1rd34nx/Batman_AC.jpg)](http://s14.postimage.org/hvumbobj5/Batman_AC.jpg)

## Other information ##

  * Details of the current and all previous versions can be found in the [Changelog](Changelog.md).
  * System requirements are listed on the [Requirements](Requirements.md) page.
  * Support and discussion is provided via this [Google Group](http://groups.google.com/group/RealTemp4RTSS).
