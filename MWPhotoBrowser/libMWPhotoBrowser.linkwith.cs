using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith("libMWPhotoBrowser.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Arm64, ForceLoad = true, Frameworks = "MapKit UIKit CoreGraphics Foundation ImageIO MessageUI")]
