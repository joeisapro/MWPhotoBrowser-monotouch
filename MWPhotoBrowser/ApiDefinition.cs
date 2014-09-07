using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MWPhotoBrowser
{
    [BaseType (typeof (UIToolbar))]
    public partial interface MWCaptionView {

        [Export ("initWithPhoto:")]
        IntPtr Constructor (MWPhoto photo);

        [Export ("setupCaption")]
        void SetupCaption ();

        [Export ("sizeThatFits:")]
        SizeF SizeThatFits (SizeF size);
    }

    [BaseType (typeof (NSObject))]
    public partial interface MWPhoto {

        [Export ("caption", ArgumentSemantic.Retain)]
        string Caption { get; set; }

        [Export ("image")]
        UIImage Image { get; }

        [Export ("photoURL")]
        NSUrl PhotoURL { get; }

        [Export ("filePath")]
        string FilePath { get; }

        [Static, Export ("photoWithImage:")]
        MWPhoto PhotoWithImage (UIImage image);

        [Static, Export ("photoWithFilePath:")]
        MWPhoto PhotoWithFilePath (string path);

        [Static, Export ("photoWithURL:")]
        MWPhoto PhotoWithURL (NSUrl url);

        [Export ("initWithImage:")]
        IntPtr Constructor (UIImage image);

        [Export ("initWithURL:")]
        IntPtr Constructor (NSUrl url);

        [Export ("initWithFilePath:")]
        IntPtr Constructor (string path);

        [Export ("underlyingImage", ArgumentSemantic.Retain)]
        UIImage UnderlyingImage { get; set; }

        [Export ("loadUnderlyingImageAndNotify")]
        void LoadUnderlyingImageAndNotify ();

        [Export ("performLoadUnderlyingImageAndNotify")]
        void PerformLoadUnderlyingImageAndNotify ();

        [Export ("unloadUnderlyingImage")]
        void UnloadUnderlyingImage ();       

        [Export ("cancelAnyLoading")]
        void CancelAnyLoading ();
    }


    [Model, BaseType (typeof (NSObject)), Protocol]
    public partial interface MWPhotoBrowserDelegate {

        [Export ("numberOfPhotosInPhotoBrowser:")]
        int numberOfPhotosInPhotoBrowser (MWPhotoBrowser photoBrowser);

        [Export ("photoBrowser:photoAtIndex:")]
        MWPhoto PhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:thumbPhotoAtIndex:")]
        MWPhoto ThumbPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:captionViewForPhotoAtIndex:")]
        MWCaptionView CaptionViewForPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:titleForPhotoAtIndex:")]
        string TitleForPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:didDisplayPhotoAtIndex:")]
        void DidDisplayPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:actionButtonPressedForPhotoAtIndex:")]
        void ActionButtonPressedForPhotoAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:isPhotoSelectedAtIndex:")]
        bool IsPhotoSelectedAtIndex (MWPhotoBrowser photoBrowser, uint index);

        [Export ("photoBrowser:photoAtIndex:selectedChanged:")]
        void PhotoAtIndex (MWPhotoBrowser photoBrowser, uint index, bool selected);

        [Export ("photoBrowserDidFinishModalPresentation:")]
        void photoBrowserDidFinishModalPresentation (MWPhotoBrowser photoBrowser);
    }

    [BaseType (typeof (UIViewController))]
    public partial interface MWPhotoBrowser { //: UIScrollViewDelegate, UIActionSheetDelegate, MFMailComposeViewControllerDelegate {

        [Export ("delegate", ArgumentSemantic.Assign)]
        MWPhotoBrowserDelegate Delegate { get; set; }

        [Export ("zoomPhotosToFill")]
        bool ZoomPhotosToFill { get; set; }

        [Export ("displayNavArrows")]
        bool DisplayNavArrows { get; set; }

        [Export ("displayActionButton")]
        bool DisplayActionButton { get; set; }

        [Export ("displaySelectionButtons")]
        bool DisplaySelectionButtons { get; set; }

        [Export ("alwaysShowControls")]
        bool AlwaysShowControls { get; set; }

        [Export ("enableGrid")]
        bool EnableGrid { get; set; }

        [Export ("enableSwipeToDismiss")]
        bool EnableSwipeToDismiss { get; set; }

        [Export ("startOnGrid")]
        bool StartOnGrid { get; set; }

        [Export ("delayToHideElements")]
        uint DelayToHideElements { get; set; }

        [Export ("currentIndex")]
        uint CurrentIndex { get; }

        [Export ("initWithPhotos:")]
        IntPtr Constructor (NSObject [] photosArray);

        [Export ("initWithDelegate:")]
        IntPtr Constructor (MWPhotoBrowserDelegate mwPhotoBrowserDelegate);

        [Export ("reloadData")]
        void ReloadData ();

        [Export ("currentPhotoIndex")]
        uint CurrentPhotoIndex { set; }

        [Export ("initialPageIndex")]
        uint InitialPageIndex { set; }

        [Export ("showNextPhotoAnimated:")]
        void ShowNextPhotoAnimated (bool animated);

        [Export ("showPreviousPhotoAnimated:")]
        void ShowPreviousPhotoAnimated (bool animated);
    }
}

