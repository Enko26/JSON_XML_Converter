   M S B A M L   `   `   `  ����H  DJsonConverter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:JsonConverterJsonConverter  5   	       JsonConverter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:JsonConverter     5   	     � Icon$  exeicon.png��5   	    � Title$ 	Conventer��5	   	    � 
ResizeMode$ NoResize=�6   #��Z��5
   	   #��Z��5   	    � WindowState$ 	Maximized=�5   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� EndPoint	 �� 
StartPoint
 � Color � Offset��%�   '�       �� 5   
   " �6-   .�5      ��  � �� 5      �� 5      $ 0.5,1&�6*   $	 0.5,0&�6;   .��5      � $

 Blue��6'   $ 0Q�64   � 5      $
 DarkBlue��6'   $ 1Q�68   5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��265* �6   �� 5      $
��131* �6   .+�5   
   �� $
��Left=�6   $��	10,96,0,0q�6,   $	��Top=�6?   $��29��6W   $	��188��6c   .��6o   Seçtiğiniz Dosya:6�   �� 5    
   -   5         ��Name$ btnLoad��5       $��Load Json Or XML��6"   $
��Left=�6=   $��
124,25,0,0q�6X   $	��Top=�6l   $	��172��6�   $��48��6�    J� RenderTransformOrigin$ 0.172,0.604&�6�   �� 5!   
   -   5         ��Name$ 
lbLoadFile��5!      $��Label��6$   $
��Left=�64   $��
10,130,0,0q�6O   $	��Top=�6c   �� 5"   
   -   5        $ btnDownloadXML��5"      $��DOWNLOAD XML��6)   $
��Left=�6@   $��487,504,0,0q�6[   $	��Top=�6p   $	��135��6�   $��58��6�   6�   �� 5#   
   -   5        $ btnConvertJsonToXml��5#      $��Json To XML Convert��6.   $
��Left=�6L   $��571,170,0,0q�6g   $	��Top=�6|   $	��188��6�   $��63��6�   6�   � 5$   
   -   5         �Name$ ProgressBar��5$   D   #��[B�6   $
��Left=�6Y   $��28��6t   $��487,397,0,0q�6�   $	��Top=�6�   $	��358��6�    � Minimum$ 0Q�6�    � Maximum$	 100Q�6�   �� 5&   
   -   5         ��Name$ ListBox1��5&      $
��Left=�6$   $	��483��6?   $��
10,156,0,0q�6L   $	��Top=�6`   $	��407��6x   �� 5'   
   -   5        $ ListBox2��5'      $
��Left=�6$   $	��478��6?   $��
10,156,0,0q�6L   $	��Top=�6`   $	��406��6x   $��1��6�   �� 5(   
   -   5        $ 	lbDegisen��5(      $&�� Dönüştürülen XML Dosyası :��6%   $
��Left=�6J   $��	20,96,0,0q�6e   $	��Top=�6x   $��1��6�   �� 5)   
   -	   5        $ btnConvertXmlToJson��5)      $��XML To Json Convert��6.   $
��Left=�6L   $��571,263,0,0q�6g   $	��Top=�6|   $	��188��6�   $��67��6�   6�   �� 5*   
   -
   5        $ btnDownloadJson��5*      $��DOWNLOAD JSON��6*   $
��Left=�6B   $��701,504,0,0q�6]   $	��Top=�6r   $	��144��6�   $��58��6�   6�   �� 5+   
   -   5        $ lbConvertingFile��5+      $��Label��6*   $
��Left=�6:   $��
20,130,0,0q�6U   $	��Top=�6i   $��1��6�   5-      5.      