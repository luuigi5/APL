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
EXPOSE 8093

# Comando per eseguire l'applicazione
CMD ["python", "app.py"]