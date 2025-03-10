#print("Hello World!")

from pytrends.request import TrendReq

# Inizializza la richiesta
pytrends = TrendReq(hl='it', tz=360)

# Definisci la parola chiave da cercare
kw_list = ["Papa"]

# Ottieni l'interesse nel tempo
pytrends.build_payload(kw_list, cat=0, timeframe='today 12-m', geo='IT', gprop='')

# Ottieni i dati sull'interesse nel tempo
interest_over_time = pytrends.interest_over_time()
print(interest_over_time)





casa1 = {
    'Id' : 1,
    'Indirizzo' : 'via San Carlo 33',
    'Città' : 'Catania',
    'Metratura' : 100,
    'Stanze' : 5
}

casa2 = {
    'Id' : 2,
    'Indirizzo' : 'via San Carlo 34',
    'Città' : 'Torino',
    'Metratura' : 120,
    'Stanze' : 6
}

complessi = [casa1, casa2]
for casa in complessi:
    if casa["Metratura"] > 100:
        print(f'La casa in {casa["Indirizzo"]} è adatta per una famiglia')
        prezzoStanza = 35
        casa["Prezzo"] = prezzoStanza * casa["Stanze"]
    else:
        print(f'La casa in {casa["Indirizzo"]} è adatta per poche persone')
        prezzoStanza = 50
        casa["Prezzo"] = prezzoStanza * casa["Stanze"]

for casa in complessi:
    print(casa)