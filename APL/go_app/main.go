package main

import (
	"fmt"
	"go_app/Socket"
	"net/http"
	"log"
)


//MAIN AVVIO SERVER
func main(){
	
	http.HandleFunc("/ws", Socket.Connect)
    serverAddr := "0.0.0.0:8092"
    
    // Avvia il server WebSocket in una goroutine separata
    go func() {
        fmt.Printf("Server WebSocket in ascolto su %s\n", serverAddr)
        if err := http.ListenAndServe(serverAddr, nil); err != nil {
            log.Fatal("Errore nell'avvio del server WebSocket:", err)
        }
    }()
    
	// Avvia il server socket in un'altra goroutine o nel thread principale
	go func() {
		fmt.Println("Avvio del server Socket...")
		Socket.StartSocketServer()
	}()

	select {}

}