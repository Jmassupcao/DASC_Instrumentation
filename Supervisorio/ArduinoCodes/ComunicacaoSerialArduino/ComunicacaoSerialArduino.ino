char rec[4]; //variável que irá receber os caracteres vindos da serial
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

void setup() {
  Serial.begin(9600);
  pinMode(13, OUTPUT);
}

void loop() {

    enviarSerial(adc, pinSolar, pinTempIn, pinTempFn, pinTempAmb, pinUmidAmb);
    
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
    rec[i]= (char)Serial.read();

    if(rec[i] == '\r')
    {
      i=0;

      if((rec[0]=='I') && (rec[1] == 'N'))
        adc = true;

      if((rec[0]=='F') && (rec[1]=='N'))
        adc = false;
    }
    else
    i++;
  }
}

void enviarSerial(bool sEvent, int one, int two, int three, int four, int five)
{
  if(sEvent)
  {
    Serial.print("entrou na funcao");
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
}
