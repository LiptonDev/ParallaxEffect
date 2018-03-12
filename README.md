# ParallaxEffect

#### ```Install-Package DevExpressMvvm```
####
```XAML
<Window ...
        xmlns:parallax="clr-namespace:ParallaxEffect;assembly=ParallaxEffect"
        xmlns:i="http://schemas.devexpress.com/winfx/2008/xaml/mvvm"
		...>

    <i:Interaction.Behaviors>
        <parallax:Parallax/>
    </i:Interaction.Behaviors>
	
	<Grid>
    ...
  </Grid>
</Window>
```

#### Добавляем AttachedProperty для нужных объектов, которые необходимо перемещать:
##### Parallax.UseParallax="True" для тех объектов, которые необходимо перемещать
```XAML
<Image Source="Images/bg.jpg"
	   Margin="-20"
	   Stretch="Fill"
	   parallax:Parallax.UseParallax="True"
	   parallax:Parallax.XOffset="120"
	   parallax:Parallax.YOffset="120"/>

<Image Source="Images/WPF_Csharp.png"
	   Width="100"
	   VerticalAlignment="Top"
	   HorizontalAlignment="Left"
	   Margin="10"
	   parallax:Parallax.UseParallax="True"
	   parallax:Parallax.XOffset="80"
	   parallax:Parallax.YOffset="30"/>
```

# Demo

![alt text](Animation.gif)
