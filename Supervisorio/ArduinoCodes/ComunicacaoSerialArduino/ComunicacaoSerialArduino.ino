char rec[100]; //variável que irá receber os caracteres vindos da serial
int i=0; //variável de controle para a variável rec

boolean adc; //variável de controle do conversor AD

int   pinSolar = 0;   //pino do conversor AD do sensor solar
int  pinTempIn = 1;  //pino do conversor AD do sensor de temperatura inicial do DASC
int  pinTempFn = 2;  //pino do conversor AD do sensor de temperatura final do DASC
int pinTempAmb = 3; //pino do conversor AD do sensor de temperatura ambiente
int pinUmidAmb = 4; //pino do conversor AD do sensor de umidade ambiente

int pinPeltier = 3; //pino usado para o controle da placa peltier
int pinMotor   = 5; //pino usado para o controle da bomba peristáltica 

String setPointTemp; //variável para amarzenar o set poit da temperatura da célula peltier
String   setPointVM; //variável para amarzenar o set point da vazão do moto 
bool stringFlag = true;
int showSPTemp;
int showSPVM;


void setup() {
  Serial.begin(9600);
  pinMode(pinPeltier, OUTPUT);
  pinMode(pinMotor, OUTPUT);
}

void loop() {

  if(adc)
  {
    showSPTemp = setPointTemp.toInt();
    showSPVM = setPointVM.toInt();
    
    enviarSerial(pinSolar, pinTempIn, pinTempFn, pinTempAmb, pinUmidAmb,showSPTemp, showSPVM);
    analogWrite(pinPeltier, setPointTemp.toInt());
    analogWrite(pinMotor, setPointVM.toInt());
  }
    
}

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
              setPointTemp += rec[a]; //armazena o valor do set point da temperatura no formato string
            }
            else //caso o valor recebido seja ":" os próximos bytes seram referentes ao set point da Vazão do motor 
            {
              if(rec[a] == ':' && (!stringFlag)) //caso seja recebido mais um byte ':' indica o fim do tratamento
              {
                break; 
              }
              else //caso não os bytes da vazão do motor são amarzenados na variável 
              {
                setPointVM += rec[a+1];
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
        setPointTemp = "";
        setPointVM   = "";

        //desliga os componentes ativos do DASC
        analogWrite(pinPeltier, 0);
        analogWrite(pinMotor, 0);
      }
        
    }
    else
      i++;
      stringFlag = true; 
  }
}

void enviarSerial(int one, int two, int three, int four, int five, int six, int seven)
{
  int adOne = analogRead(one);
  int adTwo = analogRead(two);
  int adThree = analogRead(three);
  int adFour = analogRead(four);
  int adFive = analogRead(five);

  char ad_buffer[64];

  snprintf(ad_buffer, sizeof(ad_buffer), "AN0:%04d:BN0:%04d:CN0:%04d:DN0:%04d:EN0:%04d:FN0:%04d:GN0:%04d:", 
                                                  adOne, adTwo, adThree, adFour, adFive, six, seven);
  Serial.print(ad_buffer);
  delay(300); 
}
