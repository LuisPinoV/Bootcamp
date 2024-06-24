#include <stdio.h> //para funciones como printf
#include <time.h> //para randomizar bien los numeros
#include <stdlib.h>// para rand y malloc
#include <string.h> //para manejar strings


typedef struct Persona{    //una estructura que almacena los datos de una persona
    int edad, resp, pulse, press, sex;
    float T;
    char id[7];
}Persona;

//semi cola, solo usa metodo push2 (meter al final)
typedef struct Nodo{    //una estructura que sirve para enlazar a los distintos pacientes
    Persona * dato; //dato es Persona
    struct Nodo * proximo;
}Nodo;


int randomRange(int min, int max){ //random number
    return (rand() % (max-min+1)) + min;
}

//convierte un conjunto de char (el ID) en un string, es usado por la funcion que le sigue
void arraycharcat(char **array){
    for (int i=0; i< (sizeof(array)/sizeof(array[0]))-1 ;i++){ 
   	 strcat(array[0],array[1]);
    }
}

//crea una id para el paciente
char * randID(){
    char *id = (char*)malloc(6*sizeof(char)); //reserva el espacio de memoria para el paciente
    char nums[] = "0123456789"; //crea el conjunto de numeros para generar el ID
    for (int i=0; i < (sizeof(id)/sizeof(id[0]))-2 ; i++){
   	 id[i] = nums[randomRange(0,strlen(nums)-1)]; // se genera una posicion random, se toma el numero asociado a esa posicion en nums y se asigna al id en la posicion i
    }arraycharcat(&id); // se cambia el tipo de dato del ID de array a string
    return id;
}

//llena los datos(signos vitales y edad) dentro de la estructura "Persona" aleatoriamente
Persona * personafill(){
    Persona * temp = (Persona*)malloc(sizeof(struct Persona));

    strcpy(temp->id , randID());   
    temp->sex = randomRange(0, 1);
    temp->edad = randomRange(0, 122); //122 es lo q mas ha vivido una persona
    temp->resp = randomRange(8, 40);
    temp->T = randomRange(33,43);
    temp->pulse = randomRange(0, 180);
    temp->press = randomRange(70,140);
    
    return temp;
}

//esta imprime los datos de las personas, es usada por la funcion que le sigue
void printPersona(Persona *p){
    printf("ID%s ",p->id);
    printf("%d ",p->sex); //0 o 1
    printf("%d ",p->edad);
    printf("%d ",p->resp);
    printf("%.1f ",p->T);
    printf("%d ",p->pulse);
    printf("%d\n",p->press);
}

//esta funcion recorre la estructura de datos recursivamente, usando printPersona para mostrar los datos
void printQueue(Nodo * nodo){
    if (nodo == NULL){    //condicion de borde
   	 return;
   }printPersona(nodo->dato); //imprime los datos de las personas
    printQueue(nodo->proximo); //recursividad
}

//push para formar la estructura de datos
Nodo * push2(Persona* valor, Nodo *old){
    Nodo * nodo = (Nodo *)malloc(sizeof(Nodo));
    nodo->dato = valor;
    nodo->proximo = NULL;
    
    old->proximo = nodo;    
    return nodo;
}


void main(){

//para esta ocasion generamos pacientes y sus datos
    srand(time(0)); //para randomizar correctamente
    
    Nodo * pacientes = (Nodo *)malloc(sizeof(struct Nodo)); //grupo de personas (la estructura)
    pacientes->proximo = NULL;
    pacientes = push2(personafill(), pacientes);
    Nodo* rear = pacientes; 

    printQueue(pacientes);   	 //imprime el nodo
 
    
}


