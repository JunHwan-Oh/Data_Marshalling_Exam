   M S B A M L   `   `   `  ����N  JDataMarshallingExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:DataMarshallingExam.Components.MarshallingPointer1DataMarshallingExam.Components.MarshallingPointer  5      G    ADataMarshallingExam.Components.MarshallingPointer.MarshallPtrView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Qlocal?clr-namespace:DataMarshallingExam.Components.MarshallingPointer     5      
�������  � DataContext  5	      L   FDataMarshallingExam.Components.MarshallingPointer.MarshallPtrViewModel  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ 	searchBtn��5      $��0��6   $��항목 찾기��5      $	��200��6!   $��50��6-   $
��Left=�5      $��10,0,0,0q�6,   6>   �� 5   
   $��1��6   ��5      �� *
Model.Data+ �� View 5      �� 5      .P�5      �� $	��int��6%    �� Width$	 150��62    �� DisplayMemberBinding 6>   �� *Item.IntValue+�� 5      $��double��6%   $	 150��65    6A   �� *Item.DoubleValue+�� 5      $��string��6%   $	 150��65    6A   �� *Item.StringValue+�� 5      $
��bool��6%   $	 150��63    6?   �� *Item.BoolValue+5      5!      �� 5"   
   -   5        $ editBtn��5"      $��2��6   $
��TEST��5#      $	��200��6!   $��50��6-   $��Right=�5$      $��0,0,10,0q�6-   6?   5%      5&      