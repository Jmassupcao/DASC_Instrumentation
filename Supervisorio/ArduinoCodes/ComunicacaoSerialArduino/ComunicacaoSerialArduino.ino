char rec[100]; //variável que irá receber os caracteres vindos da serial
int i=0; //variável de controle para a variável rec

/*int   adSolar;   //variável para armazenar o valor de conversão AD do sensor solar
int  adTempIn;  //variável para armazenar o valor de conversão AD do temperatura inicial 
int  adTempFn;  //variável para armazenar o valor de conversão AD do temperatura final
int adTempAmb; //variável para armazenar o valor de conversão AD do temperatura ambiente
int adUmidAmb; //variável para armazenar o valor de conversão AD do umidade ambiente  
*/
boolean adc; //variável de controle do conversor AD

/*char   ad_solar_buffer[9];  //variável para armazernar a string de tamanho n, essa variável tem que ter o tamanho n+1, referente ao falor da conversão AD do sensor solar
char  ad_tempin_buffer[9]; //varipavel para armazenar a string referente ao falor da conversão AD do do temperatura inicial  para comunicação serial
char  ad_tempfn_buffer[9]; //varipavel para armazenar a string referente ao falor da conversão AD do do temperatura final para comunicação serial
char ad_tempamb_buffer[9];//varipavel para armazenar a string referente ao falor da conversão AD do temperatura ambiente para comunicação serial
char ad_umidamb_buffer[9];//varipavel para armazenar a string referente ao falor da conversão AD do umidade ambiente para comunicação serial
*/
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


void setup() {
  Serial.begin(9600);
  pinMode(pinPeltier, OUTPUT);
  pinMode(pinMotor, OUTPUT);
}

void loop() {

  if(adc)
  {
    
    enviarSerial(pinSolar, pinTempIn, pinTempFn, pinTempAmb, pinUmidAmb);
    analogWrite(pinPeltier, setPointTemp.toInt());
    analogWrite(pinMotor, setPointVM.toInt());
  }
    /*adSolar   =   analogRead(pinSolar);     //valor de conversão AD do sensor solar 
    adTempIn  =  analogRead(pinTempIn);   //valor de conversão AD do sensor da temperatura inicial 
    adTempFn  =  analogRead(pinTempFn);   //valor de conversão AD do sensor da temperatura final
    adTempAmb = analogRead(pinTempAmb); //valor de conversão AD do sensor de temperatura ambiente
    adUmidAmb = analogRead(pinUmidAmb); //valor de conversão AD do sensor de umidade ambiente

    
    
    snprintf(ad_solar_buffer,   sizeof(ad_solar_buffer),   "ANO=%04d",   adSolar); //formatação do valor ad em string
    snprintf(ad_tempin_buffer,  sizeof(ad_tempin_buffer),  "BNO=%04d",  adTempIn);
    snprintf(ad_tempfn_buffer,  sizeof(ad_tempfn_buffer),  "CNO=%04d",  adTempFn);
    snprintf(ad_tempamb_buffer, sizeof(ad_tempamb_buffer), "DNO=%04d", adTempAmb);
    snprintf(ad_umidamb_buffer, sizeof(ad_umidamb_buffer), "ENO=%04d", adUmidAmb);
    
    
    Serial.print(ad_solar_buffer);
    delay(100);
    Serial.print(ad_tempin_buffer);
    delay(100);
    Serial.print(ad_tempfn_buffer);
    delay(100);
    Serial.print(ad_tempamb_buffer);
    delay(100);
    Serial.print(ad_umidamb_buffer);
    delay(300);*/
    
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

void enviarSerial(int one, int two, int three, int four, int five)
{
  int adOne = analogRead(one);
  int adTwo = analogRead(two);
  int adThree = analogRead(three);
  int adFour = analogRead(four);
  int adFive = analogRead(five);

  char ad_buffer[46];

  snprintf(ad_buffer, sizeof(ad_buffer), "AN0:%04d:BN0:%04d:CN0:%04d:DN0:%04d:EN0:%04d:", 
                                                  adOne, adTwo, adThree, adFour, adFive);
  Serial.print(ad_buffer);
  delay(300); 
}
