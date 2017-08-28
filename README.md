![](https://user-images.githubusercontent.com/13739520/29758046-a563b6ea-8b6d-11e7-8d22-75b18bfbd29d.png)

# Oracle-Memory-Monitor

## Laboratorio de Administracion de Bases de Datos
Este repositorio funciona como el control de versiones del laboratorio de Monitoreo de memoria de Oracle 11g. Este debe poseer las siguientes caracteristicas:

- Mostrar en tiempo real, en un grafico, el consumo de memoria de Oracle 11g
- Mostrar los picos del consumo sobre el High Water Mark
- Funcionar como un control preventivo al riesgo de disponibilidad
- Mostrar quien, como y por que se genero una carga en el consumo de memoria

## Funciones de la Solución
- Grafico en tiempo real del consumo de energia de la SGA de Oracle 11g
- Muestra el pico de consumo en la sesion
- Muestra el sql mas reciente del pico de consumo (informacion del SQL)
- Permite hacer zoom y panning sobre el grafico
- Posee una funcion para cambiar el porcentaje del High Water Mark (HWM) en **Opciones > Cambiar HWM**
- Posee un visualizador de las alertas producidas durante picos en el High Water Mark, este se localiza en **Opciones > Alertas**
  - Permite cargar y agregar los archivos .xml generados durante el sobrepaso del HWM (**Opciones > Abrir** y **Opciones > Agregar** respectivamente)
  - Depliega los datos en una tabla y permite eliminar las lineas que no se consideran importantes
  - Permite guardar el contenido de la tabla en tanto .xml como .JSON en **Opciones > Guardar Como**
  
  ## Instrucciones de Instalacion 
  Para la instalacion del Monitor, visitar la [Guia de Instalacion] (https://github.com/romogo17/Oracle-Memory-Monitor/wiki/Instrucciones-de-Instalacion)
