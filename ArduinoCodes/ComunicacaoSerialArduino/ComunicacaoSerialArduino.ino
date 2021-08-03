#include <OneWire.h>
#include <DallasTemperature.h>

//================================ Mapeamento de Hardware ============================//

#define SensorLM35 A0 //Pino o qual o sensor está conectado
 
#define Sensor 13  // Define o pino 13 como “sensor na saída do coletor”

uint8_t sensorEntrada[8] = { 0x28, 0xAA, 0xBE, 0x24, 0x54, 0x14, 0x01, 0x72 }; //Define como sensor1 o sensor desse código
uint8_t sensorSaida[8] = { 0x28, 0x31, 0x1A, 0x88, 0x13, 0x19, 0x01, 0x6E }; //Define como sensor2 o sensor desse código


OneWire oneWire(Sensor);//cria primeiramente um objeto referente ao o pino que será utilizado para transmissão de dados.
DallasTemperature sensors(&oneWire);//objeto que será responsável por representar o barramento de sensores no código
int valor = 0;
int valor3 = 0;

//=========================== Declarando Variáveis Globais =========================//

#define pinEnableMotorA 11      //Porta Digital PWM~
#define pinEnableMotorB 10     //Porta Digital PWM~

#define pinSentido1MotorA 3
#define pinSentido2MotorA 2


#define pinSentido1MotorB 7
#define pinSentido2MotorB 6

#define pinBomba 5 //pino usado para o controle da bomba peristáltica 
float vazaoBombaPWM; //variável usada para armazenar o valor em pwm do set point da vazão convertido pela regressão linear 

//float Constante = 17.05;// Constante para estabelecer a faixa de temperatura de 0 à 60 Graus ==> 1023/60 = 17.05
float  temperatura; // Variável que recebe o valor convertido para temperatura.
int ValorAjustado = 0;


#define  pinCelSolar A3   //pino do conversor AD do sensor solar
float intSolar; //variável para armazenar o valor lido na célula solar e convertido em sóis

#define  pinUmidAmb A4 //pino do conversor AD do sensor de umidade ambiente


String setPointtemp; //variável para armazenar o set poit da temperatura da célula peltier
String setPointVB;   //variável para armazenar o set point da vazão do moto 
float    showSPtemp;   //variável para armazenar o set point da temperatura convertido para Inteiro
float    vazaoBomba;    //variável para armazenar o set point da vazão da bomba peristáltica convertido para Inteiro

bool stringFlag = true; //flag logica usada no tratamento da string enviada pelo supervisório

float temp2;
float tempAmbiente;
//int Temperature;
int Temperature2;

boolean adc; //variável de iniciação do códgo, muda para true quando recebe o comando do serial 
char rec[100]; //variável que irá receber os caracteres vindos da serial
int i = 0; //variável de controle para a variável rec

void setup() {
  Serial.begin(9600);

  pinMode(SensorLM35, INPUT);//Define como Entrada o Sensor ambiente
  pinMode(pinCelSolar, INPUT); //Define como Entrada o Sensor solar

  pinMode(pinEnableMotorA, OUTPUT);
  pinMode(pinEnableMotorB, OUTPUT);

  pinMode(pinSentido1MotorA, OUTPUT);
  pinMode(pinSentido2MotorA, OUTPUT);
  pinMode(pinSentido1MotorB, OUTPUT);
  pinMode(pinSentido2MotorB, OUTPUT);

  pinMode(pinBomba, OUTPUT);
  
  //pinMode(pinPeltier, OUTPUT);

  sensors.begin();
  
  /*sensors.setResolution(SensorEntrada, 10);
  sensors.setResolution(SensorSaida, 10);

  sensors.getAddress(SensorEntrada, 0);
  sensors.getAddress(SensorEntrada, 1);*/

}

void loop() {
  
 
  //espera até que a variável adc mude para true
  if(adc){

        /*******************************************************************************************************  
    -------Converte os valores de Set Point da bomba peristaltica e da placa peltier para Inteiro-----------
    *******************************************************************************************************/
    showSPtemp = setPointtemp.toFloat();
    vazaoBomba = setPointVB.toFloat();
    
    
    /*******************************************************************************************************  
    ------------------------------função do programa: verificar a temperatura Ambiente-------------------
    *******************************************************************************************************/
    float valor_analog_SensorLM35 = float(analogRead(SensorLM35)); // Obtém o valor analógico que varia de 0 a 1023
    float tensao = (valor_analog_SensorLM35 * 5) / 1023;           // Converter esse valor para tensão elétrica((5/tensão) =  (1023/Valor analog))
    tempAmbiente = tensao / 0.010;                           // dividimos a tensão por 0.010 que representa os 10 mV

    //Serial.print("temperatura Ambiente : ");
    //Serial.println(tempAmbiente); // Mostra na serial a temperatura do sensor

    //delay(500);

    /*******************************************************************************************************
    ------------------------------função do programa:Setpoint-------------------
    *******************************************************************************************************/
    valor = showSPtemp; //valor do set point da temperatura para controlar a saída em PWM
    valor = map(valor, 0, 1023, 0, 255);

    ValorAjustado = showSPtemp;
    
    //ValorAjustado = showSPtemp / Constante;
    //Serial.print("Setpoint : ");
    //Serial.print(ValorAjustado);
    //Serial.println();
    
    delay(500);

    /*******************************************************************************************************
    ------------------------------função do programa: Sensor(Entrada) Temperatura DS18B20-------------------
    *******************************************************************************************************/
    sensors.requestTemperatures();
    delay(100);
    float temp2 = printTemperature(sensorEntrada); //Obtem o valor do sensor de entrada
    String temperatura2 = String(temp2);
    valor3 = map(valor, 0, 1023, 0, 255);
    //Serial.print(temperatura);
    if (temperatura2 == "-127.00") // acho de depois posso tirar
    {
      // do nothing
    }
    else
    {
      //Serial.print("Temperatura do NanoFluido (Entrada) : ");
      //Serial.println(sensors.getTempCByIndex(0));
      //Serial.print(temperatura2);
      //Serial.println();
      delay(500);
    }
    Temperature2 = temp2;


    /*******************************************************************************************************
    ------------------------------função do programa: Sensor(Saída) Temperatura DS18B20-------------------
    *******************************************************************************************************/
  
    sensors.requestTemperatures();
    delay(100);
    float temp = printTemperature(sensorSaida); //Obtem o valor do sensor de Saída
    String temperatura = String(temp);
    valor = map(valor, 0, 1023, 0, 255);
    //Serial.print(temperatura);
    if (temperatura == "-127.00") // acho de depois posso tirar
    {
      // do nothing
    }
    else
    {
      //Serial.print("Temperature do NanoFluido(Saída) : ");
      //Serial.println(sensors.getTempCByIndex(0));
      //Serial.print(temperatura);
      //Serial.println();
      delay(500);
    }
    
    int Temperature = temp;

    if ( Temperature > (ValorAjustado + 2) )
    {
      //digitalWrite(Rele_Peltier, HIGH);
      int valor2 = 255;
      //int valor2 = 6*valor;//Fazer uma equação para colocar a tensão idela na saída da ponte H
      analogWrite(pinEnableMotorA, 0);
      analogWrite(pinEnableMotorB, valor2); //Valor do PWM no MOTOR
      digitalWrite(pinSentido1MotorB, LOW); //Ativa o sentido para refrigerar
      digitalWrite(pinSentido2MotorB, HIGH);
      delay(1000);
    }

    if (Temperature < (ValorAjustado - 2) )
    {
      //digitalWrite(Rele_Peltier, HIGH);
      int valor2 = 255;
      //int valor2 = 6*valor;//Fazer uma equação para colocar a tensão idela na saída da ponte H
      analogWrite(pinEnableMotorB, 0);
      analogWrite(pinEnableMotorA, valor2); //Valor do PWM no MOTOR
      digitalWrite(pinSentido1MotorA, LOW); //Ativa o sentido para refrigerar
      digitalWrite(pinSentido2MotorA, HIGH);
      delay(1000);
    }
    
    /*if (Temperature >= (ValorAjustado + 2))
    {
      analogWrite(pinEnableMotorA, 0);
    }*/
    
    if ((Temperature >= (ValorAjustado - 2)) && (Temperature <= (ValorAjustado + 2)))
    {
      analogWrite(pinEnableMotorB, 0);
      analogWrite(pinEnableMotorA, 0);
    }

  /*******************************************************************************************************
  ------------------------------ Leitura e conversão do sensor solar ------------------------------------
  *******************************************************************************************************/
  intSolar = (0.286860655897221 * analogRead(pinCelSolar)) + (-0.157735967619378); //regressão linear que converte o valor de tensão lida na célula solar para o valor de referência em sóis
  
  
  /*******************************************************************************************************
  ------------------------------Controle da bomba peristáltica------------------------------------
  *******************************************************************************************************/
  vazaoBombaPWM = (2.70120497463551 * vazaoBomba) + 82.3781191907456; //regressão linear que converte o set point da vazão no valor do PWM correspondente 

  analogWrite(pinBomba, vazaoBombaPWM); //ativa a bomba com a vazão solicitada pelo set point do supervisório

  /*******************************************************************************************************
  ------------------------------Enviando as informações para a serial------------------------------------
  *******************************************************************************************************/
    enviarSerial(intSolar, temp2, temp, 25, 50, showSPtemp, vazaoBomba);
    
  }
    
}

/*******************************************************************************************************
-----------------Evento que espera a comunicação com o serial e trata o dado recebido-------------------
*******************************************************************************************************/
void serialEvent()
{
  while(Serial.available())
  {
    rec[i]= (char)Serial.read(); //caso tenha, recupera o byte e armazena na posição 'i' de 'rec'

    if(rec[i] == '\r')//verifica se o dado recebido é igual a CR (0X0D)
    {
      i=0;

      //se os primeiros caracteres forem 'IN'
      if((rec[0]=='I') && (rec[1] == 'N'))
      {
         adc = true; //Muda para verdadeiro a variável de iniciação
          
         //recebe e trata os dados do set point da Temperatura e vazão do motor 
         for(int a=3; a<=sizeof(rec); a++)
         {
            if((rec[a] != ':') && (stringFlag)) //enquanto a string recebida for diferente de ':' o valor é referente ao set point da temperatura 
            {
              setPointtemp += rec[a]; //armazena o valor do set point da temperatura no formato string
            }
            else //caso o valor recebido seja ":" os próximos bytes seram referentes ao set point da Vazão do motor 
            {
              if(rec[a] == ':' && (!stringFlag)) //caso seja recebido mais um byte ':' indica o fim do tratamento
              {
                break; 
              }
              else //caso não os bytes da vazão do motor são amarzenados na variável 
              {
                setPointVB += rec[a+1];
              }
              
              stringFlag = false; 
            
            }
         }
      }

      //Se os primeiros caractéres foram "FN"
      if((rec[0]=='F') && (rec[1]=='N'))
      {
        adc = false; //Muda para falso a variável de iniciação 

        //limpa as variáveis de set point 
        setPointtemp = "";
        setPointVB   = "";

        //desliga os componentes ativos do DASC
        analogWrite(pinEnableMotorA, 0);
        analogWrite(pinEnableMotorB, 0);
        analogWrite(pinBomba, 0);
      }
        
    }
    else
      i++;
      stringFlag = true; 
  }
}

float printTemperature(DeviceAddress deviceAddress)
{
  float tempC = sensors.getTempC(deviceAddress);
  sensors.setResolution(deviceAddress, 10);
  
  return tempC;
}

/*******************************************************************************************************
-----------------Função de envio das informações do arduino para o supervisório-------------------------
*******************************************************************************************************/

void enviarSerial(float solar, float tempEntrada, float tempSaida, int tempAmbiente, int umidadeAmbiente, float setPointTemp, float setPointVB)
{
  
  //int adSolar = analogRead(solar);
  //int adTwo = analogRead(two);
  //int adThree = analogRead(three);
  //int adTempAmbiente = analogRead(tempAmbiente);
  int adUmidadeAmbiente = analogRead(umidadeAmbiente);

  char str_solar[6];//vetor que irá armazenar os caractéres da string C-style referente à intensidade solar
  dtostrf(solar, 3, 1, str_solar); //conversão do valor em float da intensidade solar para uma C-style string, metodo necessário para enviar os valores em float pela serial

  char str_tempEntrada[6];//vetor que irá armazenar os caractéres da string C-style referente à temperatura de entrada do DASC
  dtostrf(tempEntrada, 3, 1, str_tempEntrada); //conversão do valor em float da temperatura de entrada do DASC para uma C-style string, metodo necessário para enviar os valores em float pela serial
  
  char str_tempSaida[6];//vetor que irá armazenar os caractéres da string C-style referente à temperatura de saída do DASC
  dtostrf(tempSaida, 3, 1, str_tempSaida); //conversão do valor em float da intensidade temperatura de saída do DASC para uma C-style string, metodo necessário para enviar os valores em float pela serial
  
  char str_setPointTemp[6];//vetor que irá armazenar os caractéres da string C-style referente ao Set Point temperatura
  dtostrf(setPointTemp, 3, 1, str_setPointTemp); //conversão do valor em float do Set Point da temperatura para uma C-style string, metodo necessário para enviar os valores em float pela serial

  char str_setPointVB[6];//vetor que irá armazenar os caractéres da string C-style referente ao Set Point da vazaõ da bomba
  dtostrf(setPointVB, 3, 1, str_setPointVB); //conversão do valor em float do Set Point da Vazão para uma C-style string, metodo necessário para enviar os valores em float pela serial

  char ad_buffer[64];

  snprintf(ad_buffer, sizeof(ad_buffer), "AN0:%04s:BN0:%04s:CN0:%04s:DN0:%04d:EN0:%04d:FN0:%04s:GN0:%04s:", 
                                                  str_solar, str_tempEntrada, str_tempSaida, tempAmbiente, adUmidadeAmbiente, str_setPointTemp, str_setPointVB);
  Serial.print(ad_buffer);
  delay(300); 
}
