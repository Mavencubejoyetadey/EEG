/**
 * Basic ADC reading example.
 * - connects to ADC
 * - reads value from channel
 * - converts value to analog voltage
 */
#include <SPI.h>
#include <Mcp3208.h>

#define SPI_CS      10       // SPI slave select
#define ADC_VREF    5000     // 5V Vref
#define ADC_CLK     1600000  // SPI clock 1.6MHz


//4051 Select input pins
int muxSelectPins[3] = {2, 3, 4};
int muxEnablePins[3] = {5, 6, 7};

MCP3208 adc(ADC_VREF, SPI_CS);

void setup() {

  // configure PIN mode
  pinMode(SPI_CS, OUTPUT);

  // set initial PIN state
  digitalWrite(SPI_CS, HIGH);
  
  // initialize SPI interface for MCP3208
  SPISettings settings(ADC_CLK, MSBFIRST, SPI_MODE0);
  SPI.begin();
  SPI.beginTransaction(settings);

  Serial.begin (500000);
  
  for(int i=0; i<3; i++)
  { 
    pinMode(muxSelectPins[i], OUTPUT);
    pinMode(muxEnablePins[i], OUTPUT);
    
    digitalWrite(muxEnablePins[i], HIGH);//Turns off all Mux, active low
  }
}

void loop ()
{
  unsigned long lastTime = micros();
  
  for(int i=0; i<3; i++)
  {
    digitalWrite(muxEnablePins[i], LOW); //Enable Mux

    for (int count=0; count<8; count++)
    {
      //Mux Address Selection
      for(int j=0; j<3; j++)
      {
        bool pinState = bitRead(count,j);
        
        digitalWrite(muxSelectPins[j], pinState);
      }

      int analogVal  = adc.read(MCP3208::SINGLE_0);
     analogVal = analogVal == 0 ? 1: analogVal;
      
      byte secondPart = analogVal >> 8;
      int tempVal = analogVal << 8;
byte firstPart = tempVal >> 8;
//byte firstPart = analogVal & b0000000011111111;

      Serial.write(secondPart);
      Serial.write(firstPart);
      
    }

    digitalWrite(muxEnablePins[i], HIGH); //Disable Mux
  }
  
  Serial.write(0);
  Serial.write(0);
   Serial.write(0);
  Serial.write(0);
  while(micros() - lastTime<2500);
}
