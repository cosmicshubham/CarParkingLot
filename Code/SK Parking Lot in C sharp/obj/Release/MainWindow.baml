   M S B A M L   `   `   `  ����   SK Parking Lot*    $SK_Parking_Lot_in_C_sharp.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  StarterWindow�� � Title$ SK Parking Lot��$	��542��$	��913�� � 
ResizeMode$ CanMinimize=�$��0q� � WindowStartupLocation$ Manual=�
�������
�������.���  � RowDefinitions �� $	��56* ��� $
��457* � � ColumnDefinitions �� $
��566* ��� $
��351* �.+��� -    ��Name$ TabMain��$
��Left=�$	��450��$��	10,28,0,0q�$	��Top=�$	��888��$��2��$��2��.@��� -    ��Name$ TabCustomer��$��Non-Members' Cars��$��0��$��
-2,-2,-2,0q�.��� ���	#FFF3F3F3$��0q� �� $
��323* ��� $
��559* �.+��� ���	#FFABADB3$��1q�$
��Left=�$��78��$��
10,157,0,0q�$	��Top=�$	��416��$��2���� ���	#FFABADB3$��1q�$
��Left=�$	��112��$��	10,20,0,0q�$	��Top=�$	��416��$��2���� -    ��Name$ Tab1TextboxCarList��$
��Left=�$	��373��$��
143,38,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��406��$��1��"
 �� VerticalScrollBarVisibility$

 Auto=� �� 
IsReadOnly .  �� IsUndoEnabled .  $��Consolas)�$��11(��� -   $ Tab1TextboxCarNumberAdd��$
��Left=�$��29��$��
116,38,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��2��$��1���� -   $ Tab1TextboxCarNumberPrice��$
��Left=�$��29��$��106,178,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��2��$��4���� -   $ Tab1TextboxStatus��$
��Left=�$	��151��$��
10,261,0,0q�$
	 Wrap=�$	��Top=�$	��416��$��2��$

 Auto=� .  .  �� -    ��Name$ Tab1ButtonAdd��$��Add Car��$
��Left=�$��321,116,0,0q�$	��Top=�$��87��$��29��$��2�����	#FFABADB3$��3���� -	   $ Tab1TextboxCarDescription��$
��Left=�$��29��$��
116,73,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��2��$��2���� -
   $ Tab1ButtonFare��$��
Check Fare��$
��Left=�$��221,219,0,0q�$	��Top=�$��87��$��29�����	#FFABADB3$��5���� -   $ Tab1ButtonRemove��$��
Remove Car��$
��Left=�$��321,219,0,0q�$	��Top=�$��87��$��29��$��2�����	#FFABADB3$��6���� -    ��Name$ Tab1labelCarNumber��$��Car Number :��$
��Left=�$��	29,38,0,0q�$	��Top=�$��91���� -   $ Tab1labelCarDescription��$��Description :��$
��Left=�$��	29,73,0,0q�$	��Top=�$��91���� -   $ Tab1labelEntryID��$��Parking ID :��$
��Left=�$��
29,178,0,0q�$	��Top=�$��78���� -   $ tab1buttonRefresh��$��Refresh��$��1��$
��Left=�$��26��$��	487,7,0,0q�$	��Top=�$��62�����	#FFABADB3$��8���� -    ��Name$ tab1checkboxupdate��$��Update List Automatically��$��1��$
��Left=�$��20��$��
304,13,0,0q�$	��Top=�$	��158�� J� RenderTransformOrigin$ 	0.911,0.5&� d� 	IsChecked$
 TrueY�$��7���� $��	New Entry��$
��Left=�$��25��$��40,5,0,0q�$	��Top=�$��67�����	#FFF3F3F3���	#FFABADB3�� $��Check Fare | Check out��$
��Left=�$��25��$��
40,143,0,0q�$	��Top=�$	��131�����	#FFF3F3F3���	#FFABADB3�� $��Output��$
��Left=�$��26��$��	6,237,0,0q�$	��Top=�$��85�����	#FFABADB3�� $��Non-Members' Car List��$
��Left=�$��25��$��
143,10,0,0q�$	��Top=�$	��135�����	#FFF3F3F3���	#FFABADB3$��1���� -   $ 
TabMembers��$��Members' Cars��$��
4,-2,-17,0q�$��0��.��� ���	#FFF3F3F3.+��� ���	#FFABADB3$��1q�$
��Left=�$��78��$��
10,157,0,0q�$	��Top=�$	��416���� ���	#FFABADB3$��1q�$
��Left=�$	��112��$��	10,20,0,0q�$	��Top=�$	��416���� -   $ Tab2TextboxCarList��$
��Left=�$	��373��$��
466,38,0,0q�$
	 Wrap=�$	��Top=�$	��406��$

 Auto=� .  .  $��Consolas)�$��11(��� -   $ Tab2TextboxMemberIDAdd��$
��Left=�$��29��$��
116,38,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��1���� -   $  Tab2TextboxCarNumberRemove��$
��Left=�$��29��$��106,178,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��4���� -   $ Tab2TextboxStatus��$
��Left=�$	��151��$��
10,261,0,0q�$
	 Wrap=�$	��Top=�$	��416��$

 Auto=� .   . �� -   $ Tab2ButtonAdd��$��Add Car��$
��Left=�$��321,116,0,0q�$	��Top=�$��87��$��29�����	#FFABADB3$��3���� -   $ Tab2TextboxCarDescription��$
��Left=�$��29��$��
116,73,0,0q�$
	 Wrap=�$	��Top=�$	��233��$��2���� -   $ Tab2ButtonRemove��$��
Remove Car��$
��Left=�$��321,219,0,0q�$	��Top=�$��87��$��29�����	#FFABADB3$��5���� -   $ Tab2labelMemberNumber��$��Member ID :��$
��Left=�$��	29,38,0,0q�$	��Top=�$��91���� -   $ Tab2labelCarDescription��$��Description :��$
��Left=�$��	29,73,0,0q�$	��Top=�$��91���� -   $ Tab2labelEntryID2��$��Parking ID :��$
��Left=�$��
29,178,0,0q�$	��Top=�$��72���� -   $ tab2buttonRefresh��$��Refresh��$
��Left=�$��26��$��	810,7,0,0q�$	��Top=�$��62�����	#FFABADB3$��7���� -   $ tab2checkboxupdate��$��Update List Automatically��$
��Left=�$��20��$��
627,13,0,0q�$	��Top=�$	��158��$
 TrueY�$��6���� $��	New Entry��$
��Left=�$��25��$��40,5,0,0q�$	��Top=�$��67�����	#FFF3F3F3���	#FFABADB3�� $��Remove Entry��$
��Left=�$��26��$��
40,143,0,0q�$	��Top=�$��85�����	#FFF3F3F3���	#FFABADB3�� $��Output��$
��Left=�$��26��$��	6,237,0,0q�$	��Top=�$��85�����	#FFABADB3�� $��Member Car List��$
��Left=�$��25��$��
466,10,0,0q�$	��Top=�$	��105�����	#FFF3F3F3���	#FFABADB3�� -   $ TabNewMembers��$��Members��$
��Left=�$��74��$��19,-2,-19,0q�$��0��.��� -    �Name$ TabMemberAdmin�����	#FFF3F3F3 �� $	��17* ��� $
��424* �.+��� ���	#FFABADB3$��1q�$
��Left=�$	��149��$��437,261,0,0q�$	��Top=�$	��401��$��1���� ���	#FFABADB3$��1q�$
��Left=�$��85��$��437,143,0,0q�$	��Top=�$	��401��$��1���� ���	#FFABADB3$��1q�$
��Left=�$��85��$��
437,23,0,0q�$	��Top=�$	��401��$��1���� ���	#FFABADB3$��1q�$
��Left=�$	��190��$��	10,25,0,0q�$	��Top=�$	��416��$��2���� -    $ tab3textboxName��$
��Left=�$��27��$��	70,42,0,0q�$
	 Wrap=�$	��Top=�$	��305��$��1��$��1���� -!   $ tab3textboxSSN��$
��Left=�$��29��$��	70,75,0,0q�$
	 Wrap=�$	��Top=�$	��305��$��1��$��2���� -"   $ tab3textboxPhone��$
��Left=�$��29��$��
70,109,0,0q�$
	 Wrap=�$	��Top=�$	��305��$��1��$��3���� -#   $ tab3buttonAdd��$��
Add Member��$
��Left=�$��29��$��277,200,0,0q�$	��Top=�$��89�����	#FFABADB3$��1��$��6���� -$   $ tab3labelName��$��Name :��$
��Left=�$��30��$��	25,42,0,0q�$	��Top=�$��72��$��2���� -%   $ tab3labelSSN��$��SSN :��$
��Left=�$��30��$��	25,78,0,0q�$	��Top=�$��72��$��2���� -&   $ tab3labePhone��$��Phone :��$
��Left=�$��30��$��
25,114,0,0q�$	��Top=�$��72��$��2���� -'   $ tab3textboxMemberIDsearch��$
��Left=�$��29��$��
541,46,0,0q�$
	 Wrap=�$	��Top=�$	��223��$��1��$��7���� -(   $ tab3labelIDsearch��$��Member ID :��$
��Left=�$��30��$��
453,46,0,0q�$	��Top=�$��77��$��1���� -)   $ tab3buttonSearch��$��Search��$
��Left=�$��29��$��
728,92,0,0q�$	��Top=�$��89�����	#FFABADB3$��1��$��8���� -*   $ tab3buttonRemove��$��Remove��$
��Left=�$��29��$��728,211,0,0q�$	��Top=�$��89��$ 0.244,0.586&����	#FFABADB3$��1��$��10���� -+   $ Tab3TextboxStatus��$
��Left=�$	��151��$��
10,261,0,0q�$
	 Wrap=�$	��Top=�$	��416��$

 Auto=�$��2�� .  .  �� -,   $ tab3textboxMonths��$
��Left=�$��29��$��121,150,0,0q�$
	 Wrap=�$	��Top=�$��63��$��1��$��4���� --   $ tab3labelMonth��$��Validity (in Months) :��$
��Left=�$��30��$��
25,150,0,0q�$	��Top=�$	��125��$��2���� -.   $ tab3textboxMemberIDremove��$
��Left=�$��29��$��541,167,0,0q�$
	 Wrap=�$	��Top=�$	��223��$��1��$��9���� -/   $ tab3labelIDsearch_Copy��$��Member ID :��$
��Left=�$��30��$��453,167,0,0q�$	��Top=�$��77��$��1���� -0   $! tab3textboxMemberIDvalidity��$
��Left=�$��29��$��541,278,0,0q�$
	 Wrap=�$	��Top=�$	��223��$��1��$��11���� -1   $ tab3labelIDsearch_Copy1��$��Member ID :��$
��Left=�$��30��$��453,282,0,0q�$	��Top=�$��77��$��1���� -2   $ tab3textboxMonthsincrease��$
��Left=�$��29��$��582,322,0,0q�$
	 Wrap=�$	��Top=�$	��105��$��1��$��12���� -3   $ tab3labelMonth_Copy��$��Validity (in Months) :��$
��Left=�$��30��$��453,322,0,0q�$	��Top=�$	��124��$��1���� -4   $ tab3buttonsubmit��$��Increase Validity��$
��Left=�$��29��$��710,322,0,0q�$	��Top=�$	��107��$ 0.244,0.586&����	#FFABADB3$��1��$��13���� -5   $ tab3labelhoursperday��$��Hours per day : ��$
��Left=�$��30��$��200,150,0,0q�$	��Top=�$��96��$��1���� -6   $ tab3textboxhours��$
��Left=�$��29��$��301,150,0,0q�$
	 Wrap=�$	��Top=�$��74��$��1��$��5���� -7   $ tab3labelhourIncrease��$��Hours per day : ��$
��Left=�$��30��$��453,363,0,0q�$	��Top=�$��93��$��1���� -8   $  tab3textboxhoursmanipulate��$
��Left=�$��29��$��582,364,0,0q�$
	 Wrap=�$	��Top=�$	��105��$��1��$��14���� -9   $ tab3buttonsubmit_Copy��$��
Set  hours��$
��Left=�$��29��$��710,364,0,0q�$	��Top=�$	��107��$ 0.485,0.535&����	#FFABADB3$��1��$��15���� $��Add New Member��$
��Left=�$��27��$��6,10,0,0q�$	��Top=�$	��108�����	#FFF3F3F3���	#FFABADB3$��1���� $��View Member Details��$
��Left=�$��27��$��	453,9,0,0q�$	��Top=�$	��124�����	#FFF3F3F3���	#FFABADB3$��1���� $��Remove a Member��$
��Left=�$��27��$��453,129,0,0q�$	��Top=�$	��111�����	#FFF3F3F3���	#FFABADB3$��1���� $��Edit Member Details��$
��Left=�$��27��$��453,246,0,0q�$	��Top=�$	��118�����	#FFF3F3F3���	#FFABADB3$��1���� $��Output��$
��Left=�$��26��$��	6,237,0,0q�$	��Top=�$��85�����	#FFABADB3$��2���� -:   $ TabViewMembers��$��
Statistics��$
��Left=�$��95��$��21,-2,-21,0q�$��0��.��� ���	#FFF3F3F3 �� $	��53* ��� $
��388* �.+��� ���	#FFABADB3$��1q�$��2��$
��Left=�$	��122��$��	17,52,0,0q�$	��Top=�$	��415���� ���	#FFABADB3$��1q�$��2��$
��Left=�$	��152��$��
17,231,0,0q�$	��Top=�$	��415��._��� -;   $ tab4buttoncount��$��Go��$
��Left=�$��34��$��292,132,0,-16q�$	��Top=�$	��102�����	#FFABADB3$��14���� -<   $ Tab4TextboxMemberList��$
��Left=�$	��373��$��
360,38,0,0q�$
	 Wrap=�$	��Top=�$	��406��$

 Auto=�$��1�� .  .  $��Stretch=�$��Consolas)�$��11(��� -=    ��Name$  tab4comboboxMemberSelector��$
��Left=�$��26��$��	537,7,0,0q�$	��Top=�$	��145��$��1��$��15�� �� SelectedIndex$ 0��.@��� ->    ��Name$ ComboBoxitemAllMembers��$��All Members��$
��Left=�$	��145���� -?   $ ComboBoxitemValidMembers��$��Valid Members��$
��Left=�$	��145���� -@   $  ComboBoxitemExpiredMembers��$��Validity Expired Members��$
��Left=�$	��145���� -A   $ tab4ButtonRefresh��$��Refresh��$
��Left=�$��26��$��	704,7,0,0q�$	��Top=�$��62��$��1�����	#FFABADB3$��16���� $
��Left=�$��22��$��142,202,0,0q�$	��Top=�$	��402��$ 0.5,0.5&�$��1��z�V� .~��� �� ��  �� Angle$ -90.089Q�T� � -B   $ gridRadioButton��$��28,41,12,317q�.+�	� -C    	�Name$ tab4radioPriceOn��$��On��$
��Left=�$��19��$	��Top=�$��71��$��	0,35,-5,0q�$��1��	� -D   $ tab4radioPricebetween��$
��From��$��19��$��0,78,-5,-37q�$	��Top=�$��3��(  "System.Windows.Controls.DatePicker  -E     Name$ datepick1day��$
��Left=�$��28��$��2,67,0,0q�$	��Top=�$	��126��$��1��   IsTodayHighlighted . $��2��  -F   $ datepickbetween1��$
��Left=�$��28��$��	2,114,0,0q�$	��Top=�$	��126��$��1��$��4��  -G   $ datepickbetween2��$
��Left=�$��28��$��181,114,0,0q�$	��Top=�$	��126��$��1��$��5���� -H   $ tab4to��$��to��$
��Left=�$��26��$��142,112,0,0q�$	��Top=�$��29��$��1��� -I   $ gridcountradiobuttons��$��23,244,469,25q�$��2��.+�	� -J   $ tab4radioallcustomers��$)��#Count all Entries (since beginning)��$
��Left=�$��23��$	��Top=�$	��206��$��	10,14,0,0q�$��7��	� -K   $ tab4radioallmembers��$��Count all Members��$
��Left=�$��23��$��	10,42,0,0q�$	��Top=�$	��138��$��8��	� -L   $ tab4radiocustomercars��$%��Count current Non-Members' Cars��$
��Left=�$��23��$��	10,70,0,0q�$	��Top=�$	��206��$��9��	� -M   $ tab4radioMembercars��$��Count current Member Cars��$
��Left=�$��23��$��	10,98,0,0q�$	��Top=�$	��183��$��10��	� -N   $ tab4radioparkingspots��$��Total Parking spots��$
��Left=�$��23��$��
237,14,0,0q�$	��Top=�$	��153��$��11��	� -O   $ tab4radioEmptySpots��$��Empty Parking Spots��$
��Left=�$��23��$��
237,70,0,0q�$	��Top=�$	��153��$��13��	� -P   $ tab4radioFilledSpots��$��Filled Parking Spots��$
��Left=�$��23��$��
237,42,0,0q�$	��Top=�$	��153��$��12���� $��Member Type :��$��1��$
��Left=�$��26��$��	444,7,0,0q�$	��Top=�$��88���� -Q   $ tab4buttonPrice��$��	Get Price��$
��Left=�$��34��$��205,157,0,0q�$	��Top=�$	��102��$��1�����	#FFABADB3$��6���� $��Total Price��$
��Left=�$��27��$��	43,39,0,0q�$	��Top=�$��67�����	#FFF3F3F3$��2�����	#FFABADB3�� $��
Count Data��$
��Left=�$��27��$��
43,217,0,0q�$	��Top=�$��72�����	#FFF3F3F3$��2�����	#FFABADB3�� $��Members��$
��Left=�$��25��$��
355,15,0,0q�$	��Top=�$	��105�����	#FFABADB3$��1����Z� �� -R   $ 
buttonInfo��$��i��$��1��$
��Left=�$��23��$��
308,18,0,0q�$	��Top=�$��24�� � ToolTip$ About�����	#FFABADB3$��12���� -S   $ labelDeveloper��$��Developer: Shubham Kumar��$��1��$
��Left=�$��26��$��156,425,0,0q�$	��Top=�$	��176��$��Italic$����	#FFB8AEAE$��Right=�$��1���� -T   $ buttonSerialize��$
��Save��$
��Left=�$��23��$��
205,18,0,0q�$	��Top=�$��47��$��1�����	#FFABADB3$ Save Current Data��$��10���� -U   $ buttonReset��$��Reset��$��1��$
��Left=�$��23��$��
255,18,0,0q�$	��Top=�$��50�����	#FFABADB3$ Clear Everything��$��11���� -V   $��Export��$��1��$
��Left=�$��23��$��
154,18,0,0q�$	��Top=�$��48�����	#FFABADB3$. (Export all data to a readable text file.��$��9��