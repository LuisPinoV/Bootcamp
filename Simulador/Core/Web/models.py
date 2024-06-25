from django.db import models
from django.core.validators import MinValueValidator, MaxValueValidator


class DatosModel(models.Model): #.Model es de modelos
	id = models.AutoField(primary_key=True) #identificador unico e autonomo
	id_paciente = models.CharField(max_length=8) #max 8 characteres
	sex_paciente = models.IntegerField(default=0, validators=[MinValueValidator(0),MaxValueValidator(1)]) #1 incluido
		
	edad_paciente = models.IntegerField(default=0, validators=[MinValueValidator(0),MaxValueValidator(130)])	
	rpm_paciente = models.IntegerField(default=0, validators=[MinValueValidator(8),MaxValueValidator(40)])
	temp_paciente = models.FloatField(default=0, validators=[MinValueValidator(33),MaxValueValidator(43)])
	pulse_paciente = models.IntegerField(default=0, validators=[MinValueValidator(0),MaxValueValidator(180)])
	pres_paciente = models.IntegerField(default=0, validators=[MinValueValidator(70),MaxValueValidator(140)])
	
	#para dato tipo fecha = modles.DateTimeField(auto_now_add=True)
	
	def __str__(self):
		return f"{self.id} - {self.id_paciente}" #2 - ID.....
		
