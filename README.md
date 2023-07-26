## Proyecto API con soporte Docker

Este es un archivo README que te guiará para compilar y ejecutar una aplicación de ASP.NET Core usando Docker. A continuación, se presentan los pasos necesarios para llevar a cabo el proceso:

### Compilación de la API con Docker

Para compilar la API con Docker, sigue estos pasos:

1. Asegúrate de tener Docker instalado en tu sistema.
2. Abre una terminal o línea de comandos y navega hasta la carpeta `DockerDotnetLearning.Api`.

```bash
cd /ruta/hacia/tu/proyecto/DockerDotnetLearning.Api
```

3. Ejecuta el siguiente comando para compilar la imagen de Docker:

```bash
docker build -t dockerdotnetlearning.api .
```

Este comando generará una imagen Docker con el nombre `dockerdotnetlearning.api`.

### Ejecución de la API con Docker

Para ejecutar la API usando Docker, sigue estos pasos:

1. Asegúrate de haber completado la compilación de la imagen Docker siguiendo los pasos anteriores.

2. Ejecuta el siguiente comando para iniciar un contenedor a partir de la imagen que acabamos de compilar:

```bash
docker run -d -p 5000:80 --name docker-learning-api dockerdotnetlearning.api
```

El parámetro `-d` indica que el contenedor se ejecutará en segundo plano (modo deteached). La opción `-p` mapea el puerto 5000 del host al puerto 80 del contenedor, lo que permitirá acceder a la API desde `http://localhost:5000`.

### Detener el contenedor

Si deseas detener el contenedor en cualquier momento, puedes utilizar el siguiente comando:

```bash
docker stop docker-learning-api
```

Esto detendrá el contenedor con nombre `docker-learning-api`. Para eliminar el contenedor, puedes utilizar el siguiente comando:

```bash
docker rm docker-learning-api
```

### Ejecución de la API con SQL Server usando Docker Compose

Si deseas ejecutar la API junto con SQL Server usando Docker Compose, sigue estos pasos:

1. Asegúrate de tener Docker Compose instalado en tu sistema.

2. Abre una terminal o línea de comandos y navega hasta el directorio `compose` en la raíz del proyecto.

```bash
cd /ruta/hacia/tu/proyecto/compose
```

3. Ejecuta el siguiente comando para iniciar los servicios definidos en el archivo `docker-compose.yml`:

```bash
docker-compose -p learning-docker-compose up --build
```

Este comando creará y ejecutará dos contenedores, uno para la API y otro para SQL Server. Ambos servicios estarán configurados para comunicarse entre sí.

Espero que esta guía te ayude a compilar y ejecutar la aplicación de ASP.NET Core usando Docker sin problemas. Si tienes alguna pregunta o enfrentas algún problema, ¡no dudes en preguntar!

## Ejecución con Kubernetes

Si deseas ejecutar la aplicación utilizando Kubernetes, sigue los siguientes pasos:

1. Asegúrate de tener Kubernetes instalado y configurado en tu entorno.

2. Navega hasta la carpeta `k8s` en la raíz del proyecto. Asegúrate de que los archivos `deployment.yml` y `service.yml` se encuentren en esta ubicación.

3. Para desplegar la API en Kubernetes, ejecuta el siguiente comando:

```bash
kubectl apply -f deployment.yml
```

Este comando creará un despliegue en Kubernetes utilizando la configuración definida en el archivo `deployment.yml`.

4. A continuación, crea un servicio para permitir el acceso externo a la API mediante el siguiente comando:

```bash
kubectl apply -f service.yml
```

Esto creará un servicio en Kubernetes que expone la API.

5. Verifica que los pods estén en funcionamiento ejecutando:

```bash
kubectl get pods
```

6. También, verifica que el servicio esté correctamente configurado mediante:

```bash
kubectl get services
```

Con esto, deberías tener tu API funcionando en Kubernetes y accesible a través del servicio creado.

Recuerda que el archivo `deployment.yml` debe estar configurado para utilizar la imagen Docker que hemos creado anteriormente para la API y exponer el puerto correcto.

Si deseas detener los pods, eliminar el despliegue y el servicio en Kubernetes, sigue estos pasos:

```bash
kubectl delete -f deployment.yaml -f service.yml
```
