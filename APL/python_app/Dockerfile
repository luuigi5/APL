# Use an official Python runtime as a parent image
#FROM python:3.9-slim
# Set the working directory
#WORKDIR /usr/src/app
# Copy application files
#COPY . .
# Install dependencies
#RUN pip install --no-cache-dir -r requirements.txt
# Expose the port for Flask
#EXPOSE 5000
# Define the command to run the application
#CMD ["python", "app.py"]

FROM python:3.9-slim

ENV PYTHONUNBUFFERED=1

# Cambia in /app per matchare il volume
WORKDIR /app

# Copia solo requirements first
COPY requirements.txt .

# Installa dipendenze
RUN pip install --no-cache-dir -r requirements.txt

# Copia tutto il resto dell'applicazione
COPY . .

EXPOSE 5000

# Comando per eseguire l'applicazione
CMD ["python", "app.py"]