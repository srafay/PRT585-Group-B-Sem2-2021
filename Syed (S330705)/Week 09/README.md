# Week 09 of Software Engineering Practice 2021
This is week 09 of the Software Engineering Practice. For this week, following tasks are completed:


**Converting Angular app to Ionic:**
- Cd to angular application.
- Add ionic component
	+ Run `ng add @ionic/angular`.
- Install ionic cli
	+ Run `npm install -g @ionic/cli native-run cordova-res`.
- Initialize ionic inside angular application.
	+ Run `ionic init`.
- Change outputPath `“dist/angular-ionic”` to `“www”` in the angular.json file to set folders to build Ionic project for www.
- Change `<base href=”/”>` into `<base href=”./”>` in the index.html file. 
	+ `<base href=””>` defines the base URL for all the relative URL is the document and by default, it is set to root.
- Build Android APK through Cordova
	+ Run `ionic cordova run android --project="angular-ionic"`.
- If you get one of the following errors, then install Android SDK.
	- `Failed to find 'ANDROID_SDK_ROOT' environment variable. Try setting it manually.`
	- `Failed to find 'android' command in your 'PATH'. Try update your 'PATH' to include path to valid SDK directory.`
	
	
**Install Android SDK:**
- Goto https://developer.android.com/studio and download Android Studio.
- After you install and open Android Studio, install the Android SDK as follows:
	+ Click Tools > SDK Manager.
	+ In the SDK Platforms tab, select Android 11 (latest).
	+ In the SDK Tools tab, select Android SDK Build-Tools 30 (or latest).
	+ Click OK to begin install.
- Install Java JDK 1.8.x
- Fix gradle version issues and install new and add to path if needed.
