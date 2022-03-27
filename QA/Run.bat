
set caseName=%1

del %caseName%.exe

csc %caseName%.cs /r:QAutomate.Common.dll /r:WebDriver.dll /r:nunit.framework.dll

timeout /t 3

%caseName%.exe

del %caseName%.exe


