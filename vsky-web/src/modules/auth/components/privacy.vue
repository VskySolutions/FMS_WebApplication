<template>
  <q-dialog ref="dialogRef" persistent @hide="onDialogHide">
    <q-card class="q-dialog-plugin dialog-sm">
      <q-card-section class="card-header with-tools">
        <div class="text-h2">Privacy Policy</div>
        <q-btn v-close-popup icon="o_close" class="close" flat round dense />
      </q-card-section>
      <q-separator />
      <q-card-section class="card-body scroll">
        Coming soon...
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
