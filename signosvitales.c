#include <stdio.h> //para funciones como printf
#include <time.h> //para randomizar bien los numeros
#include <stdlib.h>// para rand y malloc
#include <string.h> //para manejar strings
#include <unistd.h> //para sleep() para que el codigo tenga un lapso de tiempo entre iteracion 

typedef struct Persona{    //una estructura que almacena los datos de una persona
    int edad, resp, pulse, press;
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
    for (int i=0; i< (sizeof(array)/sizeof(array[0]))-1 ;i++){ // toma el espacio de memoria del array entero, al dividirlo por el espacio de un solo digito nos entrega el numero de digitos
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
    temp->edad = randomRange(0, 122); //122 es lo q mas ha vivido una persona
    temp->resp = randomRange(8, 40);
    temp->T = randomRange(33,43);
    temp->pulse = randomRange(0, 180);
    temp->press = randomRange(70,140);
    
    return temp;
}

//esta imprime los datos de las personas, es usada por la funcion que le sigue
void printPersona(Persona *p){
    printf("|ID%s| ",p->id);
    printf("%d años| ",p->edad);
    printf("%d rpm| ",p->resp);
    printf("%.1f°C| ",p->T);
    printf("%d ppm| ",p->pulse);
    printf("%d mmHg|\n",p->press);
}

//esta funcion recorre la estructura de datos recursivamente, usando printPersona para mostrar los datos
void printQueue(Nodo * nodo){
    if (nodo == NULL){    //condicion de borde
   	 printf("---------------------------------------------------------\n");
   	 return;}//
    printPersona(nodo->dato); //imprime los datos de las personas
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

//varia el dato entregado, en una cantidad entregada, se usa en la funcion que le sigue
int variator(int given, int variation){
    if (randomRange(0,1)==0){    //50/50 de sumar o restar la cantidad entregada
   	 given= given+variation;
    }else{
   	 given = given-variation;
    }return given;
}
//aplica la funcion anterior a cada signo vital, se usa en la funcion que le sigue
void PersonaVariator(Persona* p){
    p->resp = variator(p->resp ,1);
    p->pulse = variator(p->pulse ,2);
    p->press = variator( p->press,2);
    if (randomRange(0,1)==0){    //50/50 de aumentar o disminuir
   	 p->T = p->T+0.2;
    }else{
   	 p->T = p->T-0.2;
    }
}
// recorre la estructura modificando todos los datos
void PacientesVariator(Nodo*nodo){
    if (nodo == NULL){    //llega al final
   	 return;}
    PersonaVariator(nodo->dato); //funcion anterior
    PacientesVariator(nodo->proximo); //recursividad

}

//estas funciones evaluan el estado de cada signo vital
//reciben la edad y segun ella, ven si estan fuera o dentro del rango esperado
int respiraciones(int edad, int dato){
    if (edad >= 18){
   	 return ((dato <= 20) && (dato >= 12)) ? 0 : 1; //usamos operadores temarios
    }if (edad >= 13){
   	 return ((dato <= 16) && (dato >= 12)) ? 0 : 1;
    }if (edad >= 5){
   	 return ((dato <= 30) && (dato >= 18)) ? 0 : 1;
    }if (edad >= 0){
   	 return ((dato <= 40) && (dato >= 24)) ? 0 : 1;
}}

int temperatura(int edad, float temp){
    if (edad >= 60){
   	 return ((temp <= 36.3) && (temp >= 35.6)) ? 0 : 1;
    }if (edad >= 13){
   	 return ((temp <= 36.9) && (temp >= 35.2)) ? 0 : 1;   	 
    }if (edad >= 5){
   	 return ((temp <= 36.7) && (temp >= 35.9)) ? 0 : 1;
    }if (edad >= 0){
   	 return ((temp <= 37.3) && (temp >= 34.7)) ? 0 : 1;
}}
int pulso(int edad, int pulsaciones){
    if (edad >= 13){
   	 return((pulsaciones <= 100) && (pulsaciones >= 60)) ? 0 : 1;
    }if (edad >= 5){
   	 return ((pulsaciones <= 108) && (pulsaciones >= 68)) ? 0 : 1;
    }if (edad >= 0){
   	 return ((pulsaciones <= 150) && (pulsaciones >= 78)) ? 0 : 1;
}}
int presion(int edad, int pres){
    if (edad >= 70){
   	 return ((pres <= 143) && (pres >= 90)) ? 0 : 1;
    }if (edad >= 18){
   	 return ((pres <= 130) && (pres >= 110)) ? 0 : 1;
    }if (edad >= 13){
   	 return ((pres <= 120) && (pres >= 100)) ? 0 : 1;
    }if (edad >= 5){
   	 return ((pres <=110) && (pres >= 90)) ? 0 : 1;
    }if (edad >= 0){
   	 return ((pres <=100) && (pres >= 80)) ? 0 : 1;
}}
 //imprime el estado del signo vital (anomalo o normal)// es usada en la funcion que le sigue
void SignoStatus(int valor, char* word){ // word es el signo vital correspondiente
    if (valor== 0){     //si devuelven 0, no hay anomalia, si devuelven 1, hay anomalia
   	 printf("%s bien|", word ); 
    }else if (valor==1){ 
   	 printf("%s anomala|",  word); }
}
//imprime el estado actual del signo vital, lo usa la funcion que le sigue
void PrintPersonaStatus(Persona * p){ //recibe la estructura de datos
    printf("|ID%s|",p->id);
    SignoStatus(temperatura(p->edad,p->T),"Temperatura");//aplica la funcion del signo vital y lo usa como argumento para signo estatus
    SignoStatus(presion(p->edad,p->press),"Presion");
    SignoStatus(pulso(p->edad,p->pulse), "Pulso");
    SignoStatus(respiraciones(p->edad,p->resp), "Respiraciones");
    printf("\n");
}

//recorre e imprime estado de cada paciente
void PacienteStatus(Nodo* nodo){
    if (nodo == NULL){//condicion de borde
   	 return;
    }else{
    PrintPersonaStatus(nodo->dato); //utiliza la funcion anterior
    PacienteStatus(nodo->proximo); } //recursividad
}

void main(){

//para esta ocasion generamos pacientes y sus datos
    //1) generamos lista de 5 pacientes
    srand(time(0)); //para randomizar correctamente
    
    Nodo * pacientes = (Nodo *)malloc(sizeof(struct Nodo)); //grupo de personas (la estructura)
    pacientes->proximo = NULL;
    pacientes = push2(personafill(), pacientes);
    Nodo* rear = pacientes; 
    
    for (int i=0; i<4;i++){    //genera 4 pacientes mas 
   	 rear = push2(personafill(), rear);
    }

    //2) ahora monitoreamos a los pacientes
    
    printf("---------------------------------------------------------\n");
    printQueue(pacientes);   	 //imprime el nodo
    PacienteStatus(pacientes);    //imprime el estado
    PacientesVariator(pacientes);    //varia los datos
    printf("\n\n");  
    
}


