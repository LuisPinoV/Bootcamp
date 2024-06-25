#from django.shortcuts import render
from rest_framework import views
from rest_framework.response import Response
import json
from subprocess import  PIPE, Popen
from .models import DatosModel
from django.core import serializers
from django.http import HttpResponse
from django.db.models import Count, Avg
from django.db.models.aggregates import StdDev

#pensar, hacer, verificar

#signos vitales
#-------------------------------------------------------------------------------------------------------------
class Display_paciente_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos		
		qs = DatosModel.objects.filter(id_paciente=id_p)
		qs_json = serializers.serialize('json', qs)
		return HttpResponse(qs_json, content_type='application/json')

class Display_paciente_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos		
		pass
		
class Display_edad_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_edad = qs.edad_paciente
		qs_json={
			f'Edad paciente {id_p}':qs_edad
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class Display_sex_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_sex = qs.sex_paciente
		qs_json={
			f'Sexo paciente {id_p}':qs_sex
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class Display_rpm_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_dato = qs.rpm_paciente
		qs_json={
			f'RPM paciente {id_p}':qs_dato
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class Display_temp_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_dato = qs.temp_paciente
		qs_json={
			f'Temperatura paciente {id_p}':qs_dato
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class Display_pulse_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_dato = qs.pulse_paciente
		qs_json={
			f'Pulso paciente {id_p}':qs_dato
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class Display_pres_DataView(views.APIView): #muestra el paciente con ese id
	def get(self, request, id_p): #trae los datos
		qs = DatosModel.objects.get(id_paciente=id_p)
		qs_dato = qs.pres_paciente
		qs_json={
			f'Presion paciente {id_p}':qs_dato
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')		
#-------------------------------------------------------------------------------------------------------------
#datos
class RegistrosxEdadDataView(views.APIView): #regresa registors dentro de rango etariop especificado
	def get(self, request, edad): #trae los datos
		if edad == "baby":
			qs = DatosModel.objects.filter(edad_paciente__range=(0,4)) #SOLO LOS Q CUMPLEN
		elif edad == "kid":
			qs = DatosModel.objects.filter(edad_paciente__range=(5,12)) #SOLO LOS Q CUMPLEN
		elif edad == "young":
			qs = DatosModel.objects.filter(edad_paciente__range=(13,17)) #SOLO LOS Q CUMPLE
		elif edad == "adult":
			qs = DatosModel.objects.filter(edad_paciente__range=(18,59)) #SOLO LOS Q CUMPLEN
		elif edad == "old":
			qs = DatosModel.objects.filter(edad_paciente__range=(60,9999)) #SOLO LOS Q CUMPLEN
		else:
			return HttpResponse(json.dumps({'ERROR: string invalido, considere usar [baby, kid, young, adult, old]': edad}), content_type='application/json')		
	 
		qs_json = serializers.serialize('json', qs)
		return HttpResponse(qs_json, content_type='application/json')

class TotalRegistrosDataView(views.APIView): #cuenta total de registros
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS
		qs = DatosModel.objects.aggregate(Count("id"))
		qs_json={
			'total':qs["id__count"]
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')

class RegistrosxSexoDataView(views.APIView): #registros con el sexo q se pide
	def get(self, request, sex): #trae los datos
		qs = DatosModel.objects.filter(sex_paciente=sex) #SOLO LOS Q CUMPLEN
		qs_json = serializers.serialize('json', qs)
		return HttpResponse(qs_json, content_type='application/json')


class GetSimDataView(views.APIView): #recibe datos del simulador, los guarda con post
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS
		qs = DatosModel.objects.all()
		qs_json = serializers.serialize('json', qs)
		return HttpResponse(qs_json, content_type='application/json')

	def post(self, request): #poner datos
		ruta = "/home/marceline/Documents/Simulador/Core/Web/bin/"
		comando = "sv2" #nombre de compilado
		
		#results = self.__exec(ruta, comando).split("\n") #si imprimo multiples datos, volver a incluir
		
		datos = self.__exec(ruta, comando).split(" ")
		#for r in results:
			#datos = r.split(" ")
			#if len(datos) > 1: 
		print(datos)
		dm = DatosModel()
		dm.id_paciente = datos[0]
		dm.sex_paciente = datos[1] #considerar usar replace("0", "Male").replace("1","Female")
		dm.edad_paciente = datos[2]
		dm.rpm_paciente = datos[3]
		dm.temp_paciente = datos[4]
		dm.pulse_paciente = datos[5]
		dm.pres_paciente = datos[6]
		dm.save()
		return Response(datos)
	
	def __exec(self, base,cmd, params=""):
		res= Popen("{}{} {}".format(base,cmd,params), stdout=PIPE, stderr=PIPE, shell=True)
		res.wait()
		out, err = res.communicate()
		print(out)
		cad = ''.join(e for e in out.decode("utf-8"))
	
		return cad
class InfoDataView(views.APIView): #info, todos los servicios y sus usos
	def get(self, request): 
	
		qs_json ='simulador/ Get info del modelo y Post datos del simulador\n info/ estas aqui! Entrega todos los nombres de servicios y sus usos \n delete/<id_p>/ Agarra el ID_paciente y borra sus datos \n registrosxsexo/<sex>/ Agarra el sexo y cuenta cantidad de registros que hay \n registrosxedad/<edad>/ Agarra rango edad y cuenta cantidad de registros que hay \n totalregistros/ Número de registros en la base de datos \n display_paciente/<id_p>/ Agarra el ID_paciente y muestra toda su información\n display_edad/<id_p>/ Agarra el ID_paciente y muestra su edad \n display_sex/<id_p>/ Agarra el ID_paciente y muestra su sexo \n display_rpm/<id_p>/ Agarra el ID_paciente y muestra su RPM \n display_temp/<id_p>/ Agarra el ID_paciente y muestra su Temperatura Corporal \n display_pulse/<id_p>/ Agarra el ID_paciente y muestra su Pulso/m \n display_pres/<id_p>/ Agarra el ID_paciente y muestra su Presión/m \n modasex/ Sexo que mas se respite en la base de datos \n modaedad/ Rango etario que más se repite en la base de datosmediasignos/ Promedio de los de los signos vitales \n stdsignos/ Desviación Estándar de los signos vitales \n varsignos/ Varianza de los signos vitales\n \nPara los siguientes\n-> n_alertas_: Número de pacientes con alertas\n-> alertas_: Muestra todos los pacientes y si tienen una alerta o no\n alertas_rpm/ y n_alertas_rpm/ \nalertas_temp/ y n_alertas_temp/ \nalertas_pulse/ y n_alertas_pulse/ \nalertas_pres/ y n_alertas_pres/'
		
		qs_json = qs_json.split("\n")

		
		return Response(qs_json)#HttpResponse(json.dumps(qs_json), content_type='application/json')
		
class DeleteIdDataView(views.APIView): #borra los datos a quien le pertenece el id 
	def get(self, request, id_p): 
		qs = DatosModel.objects.filter(id_paciente=id_p).delete()
		qs_json = {'Se ha borrado la informacion del siguiente paciente':id_p}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
#-------------------------------------------------------------------------------------------------------------
#estadisticas
class ModaSexDataView(views.APIView): #regresa el sexo q es la moda
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS

		male= DatosModel.objects.filter(sex_paciente=0).count() #SOLO LOS Q CUMPLEN
		female= DatosModel.objects.filter(sex_paciente=1).count() #SOLO LOS Q CUMPLEN
		if male > female:
			qs_json={'El sexo con mayor cantidad de datos es':0}
		elif male < female:
			qs_json={'El sexo con mayor cantidad de datos es':1}
		else: 
			qs_json = {'Tienen la misma cantidad de datos':2}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
		
class ModaEdadDataView(views.APIView): #regresa el rango etario con mayor cantidad de datos
	def get(self, request): #trae los datos
		dicc = {"baby": DatosModel.objects.filter(edad_paciente__range=(0,4)).count() ,
		"kid": DatosModel.objects.filter(edad_paciente__range=(5,12)).count() ,
		"young": DatosModel.objects.filter(edad_paciente__range=(13,17)).count() ,
		"adult": DatosModel.objects.filter(edad_paciente__range=(18,59)).count() , 
		"old": DatosModel.objects.filter(edad_paciente__range=(60,9999)).count()} 
		max(dicc, key=dicc.get)
		
		qs_json={
			f'El rango etario con la mayor cantidad de pacientes es {max(dicc, key=dicc.get)}, con': dicc[max(dicc, key=dicc.get)]
		}	
		
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
	
class MediaSignosDataView(views.APIView): #regresa el promedio de cada signo vital
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS
		dicc= {"RPM":DatosModel.objects.aggregate(Avg("rpm_paciente",default=0)) ,
		"Temp":DatosModel.objects.aggregate(Avg("temp_paciente",default=0)) ,
		"Pulse": DatosModel.objects.aggregate(Avg("pulse_paciente",default=0)) ,
		"Pres": DatosModel.objects.aggregate(Avg("pres_paciente",default=0)) }		
		
		qs_json={
			'RPM promedio': round(dicc["RPM"]["rpm_paciente__avg"],2),
			'Temperatura promedio': round(dicc["Temp"]["temp_paciente__avg"],2),
			'Pulso promedio': round(dicc["Pulse"]["pulse_paciente__avg"],2),			
			'Presión promedio': round(dicc["Pres"]["pres_paciente__avg"],2)			
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')


class StdSignosDataView(views.APIView): #regresa la desviacion estandar de cada signo vital
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS
		dicc= {"RPM":DatosModel.objects.aggregate(StdDev("rpm_paciente",default=0)) ,
		"Temp":DatosModel.objects.aggregate(StdDev("temp_paciente",default=0)) ,
		"Pulse": DatosModel.objects.aggregate(StdDev("pulse_paciente",default=0)) ,
		"Pres": DatosModel.objects.aggregate(StdDev("pres_paciente",default=0)) }
				
		qs_json={
			'Desviacion Estandar de RPM': round(dicc["RPM"]["rpm_paciente__stddev"],2),
			'Desviacion Estandar de Temperatura': round(dicc["Temp"]["temp_paciente__stddev"],2),
			'Desviacion Estandar de Pulso': round(dicc["Pulse"]["pulse_paciente__stddev"],2),			
			'Desviacion Estandar de Presión': round(dicc["Pres"]["pres_paciente__stddev"],2)			
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
		
		
class VarSignosDataView(views.APIView): #regresa la varianza de cada signo vital
	def get(self, request): #trae los datos, TODA LA BASE DE DATOS
		dicc= {"RPM":DatosModel.objects.aggregate(StdDev("rpm_paciente",default=0)) ,
		"Temp":DatosModel.objects.aggregate(StdDev("temp_paciente",default=0)) ,
		"Pulse": DatosModel.objects.aggregate(StdDev("pulse_paciente",default=0)) ,
		"Pres": DatosModel.objects.aggregate(StdDev("pres_paciente",default=0)) }
				
		qs_json={
			'Varianza de RPM': round(dicc["RPM"]["rpm_paciente__stddev"]**2,2),
			'Varianza de Temperatura': round(dicc["Temp"]["temp_paciente__stddev"]**2,2),
			'Varianza de Pulso': round(dicc["Pulse"]["pulse_paciente__stddev"]**2,2),			
			'Varianza de Presión': round(dicc["Pres"]["pres_paciente__stddev"]**2,2)			
		}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')

#-------------------------------------------------------------------------------------------------------------
#alertas	
class alertas_rpm(views.APIView): 
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'rpm_paciente', 'id_paciente')
		qs_json = {}
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 18 and x['edad_paciente'] < 999:
				if x['rpm_paciente'] <= 12 or x['rpm_paciente'] >= 20:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 18:
				if x['rpm_paciente'] <= 12 or x['rpm_paciente'] >= 16:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['rpm_paciente'] <= 18 or x['rpm_paciente'] >= 30:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['rpm_paciente'] <= 24 or x['rpm_paciente'] >= 40:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
					
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class n_alertas_rpm(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs = [DatosModel.objects.filter(edad_paciente__range=(0,4), 
			rpm_paciente__range=(0,999)).exclude(rpm_paciente__range=(25,39)).count(),
			
			DatosModel.objects.filter(edad_paciente__range=(5,12), 
			rpm_paciente__range=(0,999)).exclude(rpm_paciente__range=(19,29)).count(),
			
			DatosModel.objects.filter(edad_paciente__range=(13,17), 
			rpm_paciente__range=(0,999)).exclude(rpm_paciente__range=(13,15)).count(),
			
			DatosModel.objects.filter(edad_paciente__range=(18,999), 
			rpm_paciente__range=(0,999)).exclude(rpm_paciente__range=(13,19)).count(),
			
			]
		
		qs_json = {"Numero de pacientes con alerta respiratoria": sum(qs)}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')

class alertas_temp(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'temp_paciente', 'id_paciente')
		qs_json = {}
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 60 and x['edad_paciente'] < 999:
				if x['temp_paciente'] <= 35.6 or x['temp_paciente'] >= 36.3:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 18 and x['edad_paciente'] < 60:
				if x['temp_paciente'] <= 35.2 or x['temp_paciente'] >= 36.9:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 18:
				if x['temp_paciente'] <= 35.2 or x['temp_paciente'] >= 36.9:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['temp_paciente'] <= 35.9 or x['temp_paciente'] >= 36.7:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['temp_paciente'] <= 34.7 or x['temp_paciente'] >= 37.3:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
					
		return HttpResponse(json.dumps(qs_json), content_type='application/json')	
class n_alertas_temp(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'temp_paciente', 'id_paciente')
		count = 0
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 60 and x['edad_paciente'] < 999:
				if x['temp_paciente'] <= 35.6 or x['temp_paciente'] >= 36.3:
					count += 1
					continue
			if x['edad_paciente'] >= 18 and x['edad_paciente'] < 60:
				if x['temp_paciente'] <= 35.2 or x['temp_paciente'] >= 36.9:
					count += 1
					continue
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 18:
				if x['temp_paciente'] <= 35.2 or x['temp_paciente'] >= 36.9:
					count += 1
					continue
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['temp_paciente'] <= 35.9 or x['temp_paciente'] >= 36.7:
					count += 1
					continue
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['temp_paciente'] <= 34.7 or x['temp_paciente'] >= 37.3:
					count += 1
					continue
		qs_json = {"Numero de pacientes con alerta de temperatura":count}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')	
class alertas_pulse(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'pulse_paciente', 'id_paciente')
		qs_json = {}
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 999:
				if x['pulse_paciente'] <= 60 or x['pulse_paciente'] >= 100:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['pulse_paciente'] <= 68 or x['pulse_paciente'] >= 108:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['pulse_paciente'] <= 78 or x['pulse_paciente'] >= 150:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"		
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class n_alertas_pulse(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'pulse_paciente', 'id_paciente')
		count = 0
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 999:
				if x['pulse_paciente'] <= 60 or x['pulse_paciente'] >= 100:
					count += 1
					continue
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['pulse_paciente'] <= 68 or x['pulse_paciente'] >= 108:
					count += 1
					continue
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['pulse_paciente'] <= 78 or x['pulse_paciente'] >= 150:
					count += 1
					continue
		qs_json = {"Numero de pacientes con alerta de ritmo cardiaco":count}
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
class alertas_pres(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'pres_paciente', 'id_paciente')
		qs_json = {}
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 18 and x['edad_paciente'] < 999:
				if x['pres_paciente'] <= 110 or x['pres_paciente'] >= 130:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 18:
				if x['pres_paciente'] <= 100 or x['pres_paciente'] >= 120:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['pres_paciente'] <= 90 or x['pres_paciente'] >= 110:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['pres_paciente'] <= 80 or x['pres_paciente'] >= 100:
					qs_json[x['id_paciente']] = "Alerta"
				else:
					qs_json[x['id_paciente']] = "Normal"
					
		return HttpResponse(json.dumps(qs_json), content_type='application/json')	
class n_alertas_pres(views.APIView): #revisar
	def get(self, request): #trae los datos, TODA LA BASE DE DATO
		qs= DatosModel.objects.values('edad_paciente', 'pres_paciente', 'id_paciente')
		count = 0
		print(qs)
		for x in qs:
			if x['edad_paciente'] >= 18 and x['edad_paciente'] < 99:
				if x['pres_paciente'] <= 110 or x['pres_paciente'] >= 130:
					count += 1
					continue
			if x['edad_paciente'] >= 13 and x['edad_paciente'] < 18:
				if x['pres_paciente'] <= 100 or x['pres_paciente'] >= 120:
					count += 1
					continue
			if x['edad_paciente'] >= 5 and x['edad_paciente'] < 13:
				if x['pres_paciente'] <= 90 or x['pres_paciente'] >= 110:
					count += 1
					continue
			if x['edad_paciente'] >= 0 and x['edad_paciente'] < 13:
				if x['pres_paciente'] <= 80 or x['pres_paciente'] >= 100:
					count += 1
					continue
		qs_json = {"Numero de pacientes con alerta de presion sanguinea":count}			
		return HttpResponse(json.dumps(qs_json), content_type='application/json')
		

		
		

