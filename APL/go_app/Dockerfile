# Use an official Go runtime as a parent image
FROM golang:1.19

# Set the working directory
WORKDIR /usr/src/app

# Copy application files
COPY . .

# Scarica il driver PostgreSQL
RUN go get github.com/lib/pq
RUN go get github.com/gorilla/websocket

# Build the Go application
RUN go build -o main .

# Expose the default port (optional, not used here)
EXPOSE 8080

# Define the command to run the application
CMD ["./main"]



