
int vMaxCell = 5;
int vMinCell = 0;

float soisMax = 1;
int soisMin = 0;

int cellPin = A0; 

void setup() 
{
  Serial.begin(9600);
  pinMode(cellPin, INPUT);

}

void loop() 
{
  Serial.print(sunLightIntensity());

}

int sunLightIntensity()
{
  float cell = analogRead(cellPin);

  return map(cell, vMinCell, vMaxCell, soisMin, soisMax);
}
