<template>
<div>
    <!-- <iframe class="frame" src="https://player.vimeo.com/video/263674648?autoplay=1&loop=1&title=0&byline=0&portrait=0" width="640" height="360" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe> -->
<v-layout row justify-center>
      <v-btn color="error" dark @click.stop="dialog = true">Удалить</v-btn>


      <v-dialog v-model="dialog" max-width="500px">
        <v-card>
            <v-card-title>Вы уверены, что хотите удалить данного риэлтора?</v-card-title>
            <v-card-text>
                <v-btn color="primary" flat @click.stop="dialog=false">Close</v-btn>
                <v-btn color="primary" dark>Уверен</v-btn>
            </v-card-text>
        </v-card>
      </v-dialog>
    </v-layout>
</div>    
</template>

<script>
    export default {
        data:() => ({
        dialog: false,
        dialog3: false,
        })
    }
</script>

<style scoped>
    .frame {
        float:right
    }
</style>