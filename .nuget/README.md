# NetAF.WPF
An extension library for NetAF targeting WPF and providing controls to allow NetAF to be easily integrated into WPF applications.

## Getting Started

### Running the Example
Getting started running [NetAF](https://github.com/benpollarduk/NetAF/) in WPF is easy!

* Clone the repo.
* Build and run NetAF.WPF.TestApp.

## How it Works
You need a couple of components to run a NetAF game:

* Input - a way to interact with the game.
* Output - a way to view the game.

### Input
NetAF.WPF provides some easy ways to interact with the game:

#### Prompt
The prompt allows direct text entry. Add the prompt to a window or control:

```
<controls:NetAFPrompt/>
```

This will send input directly to the active game, in a window it looks like this:

```
<Window x:Class="NetAF.WPF.TestApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="clr-namespace:NetAF.Targets.WPF.Controls;assembly=NetAF.WPF"
        mc:Ignorable="d"
        Title="Example" Height="850" Width="1000">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <controls:NetAFPrompt Grid.Row="1"/>
    </Grid>
</Window>
```

#### Command Buttons
Command buttons make it easier to interact with a game. There are a few main types:

* **NetAFCommandPicker** - functions as a general command picker for all commands.
* **NetAFMovementCommandPicker** - functions as a general command picker for movement commands.
* **NetAFRegionMapCommandPicker** - functions as a general command picker for navigating the region map.

These can be used individually or as a combination. The **ButtonLayout** control provides a preconfigured control that combines all of the above controls.

```
<layouts:ButtonLayout x:Name="ButtonLayout"/>
```

Adding that to the window:

```
<Window x:Class="NetAF.WPF.TestApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="clr-namespace:NetAF.Targets.WPF.Controls;assembly=NetAF.WPF"
        xmlns:inputLayouts="clr-namespace:NetAF.Targets.WPF.InputLayouts;assembly=NetAF.WPF"
        mc:Ignorable="d"
        Title="Example" Height="850" Width="1000">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <controls:NetAFPrompt Grid.Row="1"/>
        <inputLayouts:ButtonLayout Grid.Row="2"/>
    </Grid>
</Window>
```

### Output
NetAF provides a options for viewing the game:

#### Text Terminal
A basic terminal that just displays text without any styling.

```
<controls:NetAFMTextTerminal/>
```

Adding that to the window:

```
<Window x:Class="NetAF.WPF.TestApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="clr-namespace:NetAF.Targets.WPF.Controls;assembly=NetAF.WPF"
        xmlns:inputLayouts="clr-namespace:NetAF.Targets.WPF.InputLayouts;assembly=NetAF.WPF"
        mc:Ignorable="d"
        Title="Example" Height="850" Width="1000">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <controls:NetAFTextTerminal x:Name="Terminal" Grid.Row="0"/>
        <controls:NetAFPrompt Grid.Row="1"/>
        <inputLayouts:ButtonLayout Grid.Row="2"/>
    </Grid>
</Window>
```

#### Markup Terminal
The markup terminal is highly recommended as it provides customisable styling to frames.

```
<controls:NetAFMarkupTerminal/>
```

Adding that to the window:

```
<Window x:Class="NetAF.WPF.TestApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:controls="clr-namespace:NetAF.Targets.WPF.Controls;assembly=NetAF.WPF"
        xmlns:inputLayouts="clr-namespace:NetAF.Targets.WPF.InputLayouts;assembly=NetAF.WPF"
        mc:Ignorable="d"
        Title="Example" Height="850" Width="1000">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <controls:NetAFMarkupTerminal x:Name="Terminal" Grid.Row="0"/>
        <controls:NetAFPrompt Grid.Row="1"/>
        <inputLayouts:ButtonLayout Grid.Row="2"/>
    </Grid>
</Window>
```

#### Directing Game Output to the Terminal
The game output needs to be pointed to the terminal. This is done with adapters. In the case of a NetAFTextTerminal the terminal is passed directly to the adapter on configuration:

```csharp
using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Text;
using System.Windows;

namespace NetAF.WPF.TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var configuration = new GameConfiguration(new TextAdapter(Terminal), FrameBuilderCollections.Text, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }
    }
}
```

And in the case that markup is used:

```csharp
using NetAF.Logic;
using NetAF.Rendering.FrameBuilders;
using NetAF.Targets.Markup;
using System.Windows;

namespace NetAF.WPF.TestApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var configuration = new GameConfiguration(new MarkupAdapter(Terminal), FrameBuilderCollections.Markup, Assets.Size.Dynamic);
            GameExecutor.Execute(ExampleGame.Create(configuration));
        }
    }
}
```

With that you should be ready to go!

## Persistence
The **NetAFFileManager** control adds easy persistence options to a game:

```
<controls:NetAFFileManager/>
```

No configuration is required.

## Styling
The controls can all be styled. By default a dark style is included - Targets/WPF/Styles/Dark.xaml.

To use this style merge it with the resource dictionary of your window or control:

```
<Window.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="/NetAF.WPF;component/Targets/WPF/Styles/Dark.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Window.Resources>
```

And then apply the styles to the various controls:

```
<controls:NetAFMarkupTerminal Style="{StaticResource DarkMarkupTerminalStyle}"/>
<controls:NetAFPrompt Style="{StaticResource DarkPromptStyle}"/>
<layouts:ButtonLayout Style="{StaticResource DarkButtonLayoutStyle}"/>
```

## Example Game
The [ExampleGame](NetAF.WPF.TestApp/Example.cs) is included in the repo.

## Documentation
Please visit [https://benpollarduk.github.io/NetAF-docs/](https://benpollarduk.github.io/NetAF-docs/) to view the NetAF documentation.

## For Open Questions
Visit https://github.com/benpollarduk/NetAF.WPF/issues
