# OnRender Issue of WPF

## What is the issue?
Before your `UIElement` is added to the main visual tree, the `UIElement` may call `OnRender` every time when `InvalidateRender()` is called.
But the `OnRender` will never be called when the `UIElement` has been added and removed from the main visual tree.

## How to reproduce it?
Clone, compile and run the demo project. you can see two buttons on the right top corner. One is adding the target UIElement to the visual tree or removing it from the visual tree. The other is to call the `Invalidate()` method.
