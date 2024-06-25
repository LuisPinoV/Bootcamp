# Generated by Django 5.0.4 on 2024-05-28 16:24

import django.core.validators
from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('Web', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='datosmodel',
            name='sex_paciente',
            field=models.IntegerField(default=0, validators=[django.core.validators.MinValueValidator(0), django.core.validators.MaxValueValidator(1)]),
        ),
        migrations.AlterField(
            model_name='datosmodel',
            name='temp_paciente',
            field=models.FloatField(default=0),
        ),
    ]
