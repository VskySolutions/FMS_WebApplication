<template>
  <q-dialog ref="dialogRef" persistent @hide="onDialogHide">
    <q-card class="q-dialog-plugin dialog-sm">
      <q-card-section class="card-header with-tools">
        <div class="text-h2">Contact</div>
        <q-btn v-close-popup icon="o_close" class="close" flat round dense />
      </q-card-section>
      <q-separator />
      <q-card-section class="card-body scroll">
        Coming soon...
        <!-- <p v-for="index in 3" :key="index" class="text-body2">
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean dapibus orci sed mi scelerisque,
          vel molestie massa placerat. Sed viverra, sem quis venenatis malesuada, lacus arcu pretium turpis,
          sit amet ornare enim libero ac orci. Aenean tempor sit amet felis sed cursus. Curabitur tristique
          elit vitae congue pellentesque. Sed ornare est purus, ac ultrices lacus aliquet et. Etiam posuere
          orci at enim lacinia, a lacinia leo pharetra. Nullam placerat turpis a justo bibendum, sed gravida
          nunc posuere. Nam ut laoreet tellus. Vestibulum purus mi, posuere sed pretium porttitor, tristique
          nec metus. Pellentesque at aliquet nisl. Maecenas nec dolor feugiat, aliquam diam ac, ultricies urna.
          Nunc vulputate elit nec turpis feugiat, et semper neque accumsan.
        </p> -->
      </q-card-section>
    </q-card>
  </q-dialog>
</template>

<script setup>
import { useDialogPluginComponent } from "quasar";

defineProps({});

defineEmits([
  ...useDialogPluginComponent.emits
]);

const { dialogRef, onDialogHide } = useDialogPluginComponent();

</script>
