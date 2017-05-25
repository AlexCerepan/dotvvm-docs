### Sample 1: Basic Usage

The content inside the `<bp:ModalDialog>` element is treated as a `ContentTemplate` property which specifies the main content of the dialog.

The `IsDisplayed` property is bound to the `bool` property in the viewmodel which controls whether the dialog is shown or hidden. When the user hides the dialog, the property is set to `false` automatically.
