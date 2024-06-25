from django.contrib import admin
from django.urls import path
from Web import views


urlpatterns = [
    path('admin/', admin.site.urls),
    path('simulador/', views.GetSimDataView.as_view(), name="simulador"),
    path('info/', views.InfoDataView.as_view(), name="info"),        
    path('delete/<id_p>/', views.DeleteIdDataView.as_view(), name="delete"),
    
    path('registrosxsexo/<sex>/', views.RegistrosxSexoDataView.as_view(), name="registrosxsexo"),
    path('registrosxedad/<edad>/', views.RegistrosxEdadDataView.as_view(), name="registrosxedad"),
    path('totalregistros/', views.TotalRegistrosDataView.as_view(), name="totalregistros"),
    
    path('display_paciente/<id_p>/', views.Display_paciente_DataView.as_view(), name="display_paciente"),
    path('display_edad/<id_p>/', views.Display_edad_DataView.as_view(), name="display_edad"),
    path('display_sex/<id_p>/', views.Display_sex_DataView.as_view(), name="display_sex"),
    path('display_rpm/<id_p>/', views.Display_rpm_DataView.as_view(), name="display_rpm"),
    path('display_temp/<id_p>/', views.Display_temp_DataView.as_view(), name="display_temp"),
    path('display_pulse/<id_p>/', views.Display_pulse_DataView.as_view(), name="display_pulse"),
    path('display_pres/<id_p>/', views.Display_pres_DataView.as_view(), name="display_pres"),
    
    path('modasex/', views.ModaSexDataView.as_view(), name="modasex"), 
    path('modaedad/', views.ModaEdadDataView.as_view(), name="modaedad"),               
    path('mediasignos/', views.MediaSignosDataView.as_view(), name="mediasignos"), 
    path('stdsignos/', views.StdSignosDataView.as_view(), name="stdsignos"), 
    path('varsignos/', views.VarSignosDataView.as_view(), name="varsignos"), 
    
    path('alertas_rpm/', views.alertas_rpm.as_view(), name="alertas_rpm"),    
    path('n_alertas_rpm/', views.n_alertas_rpm.as_view(), name="n_alertas_rpm"), 
     
    path('alertas_temp/', views.alertas_temp.as_view(), name="alertas_temp"),
    path('n_alertas_temp/', views.n_alertas_temp.as_view(), name="n_alertas_temp"),  
    path('alertas_pulse/', views.alertas_pulse.as_view(), name="alertas_pulse"),
    path('n_alertas_pulse/', views.n_alertas_pulse.as_view(), name="n_alertas_pulse"), 
    path('alertas_pres/', views.alertas_pres.as_view(), name="alertas_pres"),
    path('n_alertas_pres/', views.n_alertas_pres.as_view(), name="n_alertas_pres"),          
                         
]
