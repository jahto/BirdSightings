# Kuvaus

Pienimuotoinen työharjoitustehtävä. 

# Asennus

- kloonaa repo
- vaihda hakemistoon docker
- aja komento docker-compose up -d
- odottele hetken...
- avaa selaimella sivu http://localhost:8080/ tai vaihtoehtoisesti sen koneen osoitteella, johon asensit paketin

Jos portti 8080 on jo käytössä, muokkaa ensin tiedostossa docker-compose.yml olevaa kohtaa
```
    ports:
        - "8080:80"
```
ja valitse sopivampi.
