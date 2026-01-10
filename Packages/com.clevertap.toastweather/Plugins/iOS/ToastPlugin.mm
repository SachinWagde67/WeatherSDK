#import <UIKit/UIKit.h>

extern "C"
{
    void ShowNativeToast(const char* message)
    {
        NSString* msg = [NSString stringWithUTF8String:message];

        UIAlertController* alert =
        [UIAlertController alertControllerWithTitle:@"Weather"
                                            message:msg
                                     preferredStyle:UIAlertControllerStyleAlert];

        UIAlertAction* ok =
        [UIAlertAction actionWithTitle:@"OK"
                                 style:UIAlertActionStyleDefault
                               handler:nil];

        [alert addAction:ok];

        UIViewController* root =
        [UIApplication sharedApplication].keyWindow.rootViewController;

        [root presentViewController:alert animated:YES completion:nil];
    }
}