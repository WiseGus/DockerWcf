## WCF demo app (server) .Net 4.7.2 container instructions

### Build
```
$ docker build -t dockerwcfdemo:1.0.0 .
```

### Tag
```
$ docker tag dockerwcfdemo:1.0.0 {image_registry}.azurecr.io/dockerwcfdemo:1.0.0
```

### Push
```
$ az login
$ az acr login --name {image_registry}
$ docker push {image_registry}.azurecr.io/dockerwcfdemo:1.0.0
```