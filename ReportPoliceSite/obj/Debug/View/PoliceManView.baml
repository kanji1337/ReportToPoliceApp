   M S B A M L   `   `   `  ????K  GReportPoliceSite, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ReportPoliceSite.ViewReportPoliceSite.View  5   	   G(clr-namespace:ReportPoliceSite.ViewModelReportPoliceSite.ViewModel  6;   )    #ReportPoliceSite.View.PoliceManView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ReportPoliceSite.View     5   	   >	viewmodel(clr-namespace:ReportPoliceSite.ViewModel     6;     ? Title$  PoliceManView??5   	   $	??950??6   $
??1000??6,    ? WindowStartupLocation$ CenterScreen=?5	   	   .??5
      ? -   5         ?Name$ 
layoutGrid??5
      ???#272537 ? ColumnDefinitions 5   
   ?? 5       ? RowDefinitions 5   
   ?? 5      $	??120 ?6   ?? 5      .+?5   
   ?? $??0??6   $	??100??6"   $??	0,20,20,0q?61   $	??Top=?6D   $	??950??6]   $??4??6m   .+?5      ?  5      ?? 5      $
??133* ?6'   ?? 5      $
??155* ?6'   ?? 5      $
??180* ?6'   ?? 5      $
??156* ?6'   ?? 5      $
??156* ?6'   .+?5      ?? $??Полицейский??6   $
??Wrap=?6/   $	??Top=?6C   $??Center=?6[   
???????$??18(?6?   6?   ?? 5      $
??Wrap=?68   $??Center=?6L   $??Center=?6g   
???????$??20(?6?   ??6   ?? *
PoliceName+6?   ?? 5      {?. $
??Auto??6N   $??20(?6\    %  !MaterialDesignOutlinedLightButton#??[  6j   $??1??6?   ??6*   ?? *HomeViewCommand+.??5      ??  ?? TextAlignment$ Center=?6    Главная6@   5       ?? 5!      {?. $
??Auto??6Q   $??2??6a   $??20(?6q   #??[  6   $??1,0,0,0q?6?   ??6*   ?? *ViewReportsCommand+.??5"      ?? $ Center=?6    Список?? 6@   заявлений6V   5#      ?? 5$      {?. $
??Auto??6N   $??4??6]   $??20(?6m   #??[  6{   ??6*   ?? *ExitUserCommand+.??5%      ?? $ Center=?6    
Выйти6>   5&      5'      5(      ?? 5)   
   $??1??6   $??0??6&   $??40, 0, 40, 40q?66   ??6M   ?? *CurrentView+5*      5+      